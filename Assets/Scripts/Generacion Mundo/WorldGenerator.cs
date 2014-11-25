using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator 
{	
	public int[,] m_tablero;
	//Random m_random;

	int m_maximaDecena;

	public WorldGenerator(int maximaDecena)
	{
		m_maximaDecena = maximaDecena;
	}
	
	public void generaMundo(int tamX, int tamY,int numeroCasillas,int tamBorde)
	{
		int [,] tableroInicial= new int[tamX,tamY];

        for (int i = 0; i < tamX; i++)
        {
            for (int j = 0; j < tamY; j++)
            {
				tableroInicial[i, j] = -1;                
            }
        }

		//bordes laterales
		for(int i=0;i< tamBorde;i++)
		{
			for(int j=0;j< tamX;j++)
			{
				tableroInicial[i, j] = -3;
				tableroInicial[i+tamX-tamBorde,j]=-3;
			}
		}
		//bordes superiores
		for(int j=0;j< tamBorde;j++)
		{
			for(int i=0;i< tamY;i++)
			{
				tableroInicial[i, j] = -3;
				tableroInicial[i,j+tamY-tamBorde]=-3;
			}
		}


		int posInicioX = tamX / 2;
		int posInicioY = tamY / 2;
		
		//int orientacionResult,posXResult,posYResult;
		tableroInicial [posInicioX,posInicioY] = 4;//salida
		int orientacion = 0;
		generaMundo(orientacion,posInicioX,posInicioY+1,tableroInicial,numeroCasillas,tamX,tamY);
			//out orientacionResult,out posXResult, out posYResult, 
			//out m_tablero
		postProcesado ();	
		
	}
	private void postProcesado()
	{

	}

	private bool generaMundo(int orientacion, int posX, int posY, int[,] tablero,int numeroCasillas,int tamXTotal,int tamYTotal
							//out int orientacionResult, out int posXResult,out int posYResult, 
							//out int[,] tableroResult
							)
	{
		
		if(numeroCasillas==0)
		{
			tablero[posX,posY]=5+orientacion;//meta;
			m_tablero=tablero;
			return true;
		}
		
		//hay mas que hacer
		
		//generamos las casillas que podrian entrar por tamaño
		//las reordenamos de manera aleatoria
		
		//hacemos bucle
			//la colocamos(actualizamos la copia del tablero)
			//actualizamos la orientacion
			//actualizamos la posicion X,Y
			//llamamos a generar mundo con numeroCasillas -1
				//si devuelve true-> tablero ya generado-> paramos el bucle
				//si devuelve false-> tablero erroneo-> siguiente opcion
		
		Casilla[] casillasValidas= dameCasillas(tablero,posX,posY,orientacion,tamXTotal,tamYTotal);
		bool pararBucle=false;
		int casillaActual=0;
		int [,]tableroResult=tablero;
		
		while(casillasValidas!= null && !pararBucle && casillaActual != casillasValidas.Length)
		{
			Casilla actual= casillasValidas[casillaActual];
			actual.rellenaTablero(out tableroResult,tablero,orientacion,posX,posY);
			int giroDestino;
			actual.destinoGiro(out giroDestino,orientacion);
			int posXDestino,posYDestino;
			actual.destinoPosicion(out posXDestino,out posYDestino,posX,posY,orientacion);


		//	Debug.Log("Actual:" +numeroCasillas+" Posicion X:" + posXDestino + " PosicionY: "+ posYDestino+" giro:"+ orientacion);
			
			pararBucle=generaMundo(giroDestino,posXDestino,posYDestino,tableroResult,numeroCasillas-1,tamXTotal,tamYTotal);

			casillaActual++;
		
			if(!pararBucle)
			{
				actual.desRellenarTablero(out tablero,tableroResult,posX,posY,orientacion);
			}
		}
		
		if(pararBucle)
		{			
			return true;
		}
		else
		{
			return false;	
		}
		
	}

	Casilla[] dameCasillas (int[,] tablero, int posX, int posY, int orientacion,int tamXTotal,int tamYTotal)
	{
		//investigamos una a una de las casillas que pueden ser
		Recta r= new Recta();
		GiroSimpleDerecha gsd= new GiroSimpleDerecha();
		GiroSimpleIzquierda gsi= new GiroSimpleIzquierda();
		GiroDobleDerecha gdd = new GiroDobleDerecha ();
		GiroDobleIzquierda gdi = new GiroDobleIzquierda ();
		GiroTripleDerecha gtd = new GiroTripleDerecha ();
		GiroTripleIzquierda gti = new GiroTripleIzquierda ();
		
		List<Casilla> lista= new List<Casilla>();
		
		if(r.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal) && m_maximaDecena >= r.m_decena)
		{
			lista.Add(r);
		}
		if(gsd.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gsd.m_decena)
		{
			lista.Add(gsd);
		}
		if(gsi.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gsi.m_decena)
		{
			lista.Add(gsi);
		}

		if(gdd.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gdd.m_decena)
		{
			lista.Add(gdd);
		}

		if(gdi.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gdi.m_decena)
		{
			lista.Add(gdi);
		}

		if(gtd.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gtd.m_decena)
		{
			lista.Add(gtd);
		}
		if(gti.esValida(tablero,posX,posY,orientacion,tamXTotal,tamYTotal)&& m_maximaDecena >= gti.m_decena)
		{
			lista.Add(gti);
		}

		if(lista.Count == 0)
		{
			return null;	
		}
		Casilla[] devolver= new Casilla[lista.Count];
		int cuenta=0;
		while(lista.Count >0)
		{
			int indice=GestorRandom.getInstance().getNumeroAleatorio(0,lista.Count);
			devolver[cuenta]=lista[indice];
			cuenta++;
			lista.RemoveAt(indice);
		}		
		
		return devolver;
	}
}
