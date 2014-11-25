using UnityEngine;
using System.Collections;

public class CreadorMundos : MonoBehaviour {

    public int[,] m_tablero;

	public int m_ancho=10;
	public int m_alto=10;
	public int m_casillas=10;
	public int maximoDecena=60;
	public int m_tamBorde=5;

	public GameObject Recto;
	public GameObject Vacio;
	public GameObject Borde;
	public GameObject GiroDerecha;
	public GameObject GiroIzquierda;
	public GameObject Salida;
	public GameObject Meta;
	public GameObject Giro2Derecha;
	public GameObject Giro2Izquierda;
	public GameObject Giro3Derecha;
	public GameObject Giro3Izquierda;

	public ArrayList listaCasillas= new ArrayList();

	public GameObject[,] m_ArrayCasillas;

	private WorldGenerator wg;

	public void MyPreStart()
	{
		wg = new WorldGenerator(maximoDecena);
	}

	// Use this for initialization
	public void MyStart () 
	{
		//float t1 = Time.realtimeSinceStartup;
		wg.generaMundo(m_ancho,m_alto,m_casillas,m_tamBorde);
		m_ArrayCasillas = new GameObject[m_ancho, m_alto];
        m_tablero=wg.m_tablero;
        //Debug.Log("Tablero generado");

		//float t2 = Time.realtimeSinceStartup;

		//Debug.Log("Tiempo transcurrido: "+(t2-t1));
	}

	public  void dibujarTablero()
	{
		Renderer m_renderer = Recto.renderer;
		float aumentoX = m_renderer.bounds.size.x;
		float aumentoZ = m_renderer.bounds.size.z;

		float mitadX = m_ancho / 2;
		float mitadZ = m_alto / 2;

		
		float acumX = mitadX * aumentoX * -1;
		float acumZ = mitadZ * aumentoZ * -1;
		float baseZ = acumZ;


		Recta myRecta = new Recta ();
		GiroSimpleDerecha mygsd = new GiroSimpleDerecha ();
		GiroSimpleIzquierda mygsi = new GiroSimpleIzquierda ();
		GiroDobleDerecha gdd = new GiroDobleDerecha ();
		GiroDobleIzquierda gdi = new GiroDobleIzquierda ();
		GiroTripleDerecha gtd = new GiroTripleDerecha ();
		GiroTripleIzquierda gti = new GiroTripleIzquierda ();

		for(int i=0;i< m_ancho;i++)
		{
			acumZ=baseZ;
			for(int j=0;j<m_alto;j++)
			{
				Vector3 posicion;
				posicion.x=acumX;
				posicion.y=0;
				posicion.z=acumZ;
				int decena;
				GameObject go;
				int casilla=m_tablero[i,j];
				if(casilla<0)
				{
					decena=casilla;
				}
				else
				{
					decena=casilla / 10;
				}
				
				switch(decena)
				{
				case -3:go=(GameObject) Instantiate(Borde, posicion, Quaternion.identity); break;
				case -1:go=(GameObject) Instantiate (Vacio, posicion, Quaternion.identity); break;
				case 0:
					if(casilla==4)
					{
						go= myRecta.dibujarCasilla(casilla,Salida,posicion);
					}
					else
					{
						if(casilla>=5)
						{
							go=myRecta.dibujarCasilla(casilla-5,Meta,posicion);
						}
						else
						{
							go=myRecta.dibujarCasilla(casilla,Recto,posicion);
						}
					}
					break;				
				case 1: go=mygsd.dibujarCasilla(casilla,GiroDerecha,posicion);break;
				case 2: go=mygsi.dibujarCasilla(casilla,GiroIzquierda,posicion);break;
				case 3: go=gdd.dibujarCasilla(casilla,Giro2Derecha,posicion);break;
				case 4: go=gdi.dibujarCasilla(casilla,Giro2Izquierda,posicion);break;
				case 5: go=gtd.dibujarCasilla(casilla,Giro3Derecha,posicion);break;
				case 6: go=gti.dibujarCasilla(casilla,Giro3Izquierda,posicion);break;
				default: go= myRecta.dibujarCasilla(casilla,Salida,posicion); break;
				}
				
				acumZ+= aumentoZ;

				m_ArrayCasillas[i,j]=go;
			}
			acumX+= aumentoX;
		}

	}

	public void rellenarTriggers()
	{
		int posicionX = m_ancho / 2;
		int posicionY = m_alto / 2;
		int idTrigger = 0;
		m_ArrayCasillas [posicionX, posicionY].GetComponentInChildren<TriggerRegister> ().id = idTrigger;
		listaCasillas.Add(m_ArrayCasillas [posicionX, posicionY]);
		idTrigger++;
		posicionY+=1;
		int orientacionTemporal = 0;

		bool continuar = true;

		while(continuar)
		{
			int idCasilla= m_tablero[posicionX,posicionY];
			if(idCasilla>=5 && idCasilla<=8)
			{//meta
				continuar=false;
				m_ArrayCasillas [posicionX, posicionY].GetComponentInChildren<TriggerRegister> ().id = idTrigger;
				listaCasillas.Add(m_ArrayCasillas [posicionX, posicionY]);
			}
			else
			{
				Casilla casillaAux= dameCasilla(idCasilla);
				m_ArrayCasillas [posicionX, posicionY].GetComponentInChildren<TriggerRegister> ().id = idTrigger;
				listaCasillas.Add(m_ArrayCasillas [posicionX, posicionY]);
				//actualizacion
				casillaAux.destinoPosicion(out posicionX,out posicionY,posicionX,posicionY,orientacionTemporal);
				casillaAux.destinoGiro(out orientacionTemporal,orientacionTemporal);
				idTrigger++;
			}
			
		}
	}

	private Casilla dameCasilla(int id)
	{
		int decena;
		if(id<0)
		{
			decena=id;
		}
		else
		{
			decena=id/10;
		}
		Casilla devolver;
		switch(decena)
		{
		case 0: devolver= new Recta();break;
		case 1: devolver=new GiroSimpleDerecha();break;
		case 2: devolver=new GiroSimpleIzquierda();break;
		case 3: devolver=new GiroDobleDerecha ();break;
		case 4: devolver=new GiroDobleIzquierda ();break;
		case 5: devolver=new GiroTripleDerecha ();break;
		case 6: devolver=new GiroTripleIzquierda ();break;
		default: devolver= new Recta();break;
		}
		return devolver;

	}

	public ArrayList getListaCasillas()
	{
		return listaCasillas;
	}

}
