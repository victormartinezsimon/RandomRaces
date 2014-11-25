using UnityEngine;
using System.Collections;
using System.Threading;

public class GameDirector : MonoBehaviour {

	public int semilla=16041990;

	public GameObject coche;
	public GameObject pantallaCarga;
	public Camera cameraCoche;
	public Camera cameraPantallaCarga;

	private CreadorMundos cm;
	public Vector3 modificacionSalida= new Vector3(-5,20,0);

	private bool started=false;
	private bool finished=false;
	private bool hayTrampas = false;
	private int idActual=-1;

	public float timeBlinkGround = 0.33f;
	public float timeBlinkTimer = 0.6f;
	private float timeBlinkAcum=0;
	public float timeWaitChangeScene=5.0f;
	private float timeWaitChangeSceneAcum = 0;

	public string cambioScena;
	public string cambioScenaGoogleGames;

	private float timeCarrera=0;

	public GUIText textoCronometro;

	private Thread th ;
	private bool primeraVez=false;
	private bool inThread=false;

	public GameObject[] cosasOcultarThread;
	public GameObject[] cosasMostrarThread;


	public GestionLogros logrosAcabadaCarrera;
	public SubirTiempos m_subirTiempos;
	
	// Use this for initialization
	void Start () 
	{
		cm = GetComponent<CreadorMundos> ();
		PreThread ();
		th = new Thread (ThreadWork);
		th.Start ();
	}

	private void PreThread()
	{
		for(int i=0;i< cosasOcultarThread.Length;i++)
		{
			cosasOcultarThread[i].SetActive(false);
		}
		for(int i=0;i< cosasMostrarThread.Length;i++)
		{
			cosasMostrarThread[i].SetActive(true);
		}

		GameManager gm = GameManager.getInstance ();
		
		if(gm.SemillaFijada)
		{
			GestorRandom.getInstance(gm.Semilla);
			cm.MyPreStart ();
		}
		else
		{
			GestorRandom.getInstance(semilla);
			cm.MyPreStart ();
		}


	}
	private void PostThread()
	{
		cm.dibujarTablero ();
		cm.rellenarTriggers ();

		for(int i=0;i< cosasOcultarThread.Length;i++)
		{
			cosasOcultarThread[i].SetActive(true);
		}
		for(int i=0;i< cosasMostrarThread.Length;i++)
		{
			cosasMostrarThread[i].SetActive(false);
		}


		resetCar ();
		started=false;
		finished=false;


	}

	private void ThreadWork()
	{
		inThread = true;
		cm.MyStart ();			
		inThread = false;

	}

	private void resetCar()
	{
		Vector3 posicionSalida = Vector3.zero;
		posicionSalida.x = posicionSalida.x +modificacionSalida.x;
		posicionSalida.y = posicionSalida.y + modificacionSalida.y;
		posicionSalida.z = posicionSalida.z +modificacionSalida.z;
		coche.transform.position = posicionSalida;

		coche.transform.rotation = Quaternion.identity;

		coche.rigidbody.velocity = Vector3.zero;
	}



	public void TriggerID(int id)
	{
		if(idActual+1 == id)
		{
			if(hayTrampas)
			{
				//quitamos el color rojo
				GameObject aux=(GameObject)(cm.getListaCasillas()[idActual+1]);
				aux.renderer.material.SetColor("_Color",Color.white);
				textoCronometro.color=Color.white;
			}
			//todo correcto
			idActual++;
			if(idActual==0)
			{
				started=true;
				timeCarrera=0;
			}

			if(idActual== cm.m_casillas+1)
			{
				finished=true;
				timeBlinkAcum=0;
			}
			hayTrampas=false;
		}
		else
		{

			//hay trampas solo si hemos empezado y no hemos acabado
			if(started && !finished && id> idActual+1)
			{
				hayTrampas=true;
				timeBlinkAcum=0;
				textoCronometro.color=Color.red;
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!inThread)
		{
			if(!primeraVez)
			{
				primeraVez=true;
				PostThread();
			}
			gestionEnCarrera();

		}
		else
		{
			GestorRandom.getInstance().generaNumero();
		}

	}

	private void gestionEnCarrera()
	{
		if(hayTrampas && ! finished && started)
		{
			timeBlinkAcum+=Time.deltaTime;
			if(timeBlinkAcum> timeBlinkGround)
			{
				GameObject aux=(GameObject)(cm.getListaCasillas()[idActual+1]);
				aux.renderer.material.SetColor("_Color",Color.red);
			}
			else
			{
				GameObject aux=(GameObject)(cm.getListaCasillas()[idActual+1]);
				aux.renderer.material.SetColor("_Color",Color.white);
			}
			if(timeBlinkAcum>= 2* timeBlinkGround)
			{
				timeBlinkAcum=0;
			}
			
		}
		
		if(finished)
		{
			timeBlinkAcum+=Time.deltaTime;
			timeWaitChangeSceneAcum+=Time.deltaTime;

			if(timeWaitChangeSceneAcum> timeWaitChangeScene)
			{
				cambiarScena();
			}

			if(timeBlinkAcum> timeBlinkTimer)
			{
				textoCronometro.enabled=false;
			}
			else
			{
				textoCronometro.enabled=true;
			}
			if(timeBlinkAcum>= 2* timeBlinkTimer)
			{
				timeBlinkAcum=0;
			}
			
		}
		else
		{
			if(started)
			{
				timeCarrera+=Time.deltaTime;
			}
		}
		
		textoCronometro.text = formatearTiempo();
	}


	private string formatearTiempo()
	{
		return timeCarrera.ToString();
	}

	private void cambiarScena()
	{
		#if UNITY_EDITOR
			Application.LoadLevel (cambioScena);
		#else
			gestionLogros();
			m_subirTiempos.SubirTiempo (timeCarrera);			
			Application.LoadLevel(cambioScenaGoogleGames);
		#endif

	}

	public void resetScene()
	{
		resetCar ();
		started = false;
		finished = false;
		timeCarrera = 0;
		GameObject aux=(GameObject)(cm.getListaCasillas()[idActual+1]);
		aux.renderer.material.SetColor("_Color",Color.white);
		textoCronometro.color=Color.white;
		idActual=-1;
	}
	private void gestionLogros()
	{
		logrosAcabadaCarrera.desbloquearLogro (timeCarrera);
	}

}
