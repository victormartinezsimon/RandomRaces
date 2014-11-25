using UnityEngine;
using System.Collections;

public class GestorRandom 
{
	private static GestorRandom gr;

	private bool solicitadoNumero;
	private int m_rangoMenor;
	private int m_rangoMayor;
	private int numeroAleatorio;
	private bool numeroGenerado;

	public static GestorRandom   getInstance(int semilla=0)
	{
		if(gr==null)
			gr= new GestorRandom(semilla);
		return gr;
	}

	public static void deleteInstance()
	{
		if(gr!=null)
		{
			gr=null;
		}
	}

	private GestorRandom(int semilla)
	{
		Random.seed = semilla;
		solicitadoNumero = false;
		numeroGenerado = false;
	}

	public void generaNumero()
	{
		if(solicitadoNumero)
		{
			numeroAleatorio= Random.Range(m_rangoMenor,m_rangoMayor);
			numeroGenerado=true;
		}
	}

	public int getNumeroAleatorio(int rangoMenor, int rangoMayor)
	{
		if(!solicitadoNumero)
		{
			m_rangoMayor = rangoMayor;
			m_rangoMenor = rangoMenor;
			solicitadoNumero = true;
			numeroGenerado = false;
			while (!numeroGenerado);
			solicitadoNumero = false;
			return numeroAleatorio;
		}
		Debug.Log ("Error con los numeros aleatorios");
		return 0;
	}
}
