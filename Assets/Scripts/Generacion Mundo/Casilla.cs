using UnityEngine;
using System.Collections;
using UnityEngine;

public abstract class Casilla : MonoBehaviour
{
	public int m_decena;
	public int m_tamanyo;
	
	public Casilla(int decena,int tamanyo){m_decena=decena;m_tamanyo=tamanyo;}
	public abstract void destinoGiro(out int giroDestino,int giro);
	
	public abstract void destinoPosicion(out int X, out int Y,int actualX, int actualY,int giro);
	protected void destinoPosicion(out int X, out int Y,int actualX, int actualY, int giro, int[] Xs, int[] Zs)
	{
		X=actualX+ Xs[giro];
		Y=actualY+ Zs[giro];
	}
	
	public abstract void rellenaTablero(out int[,] tableroSalida, int [,] tablero,int giro,int posX,int posY);
	public abstract void desRellenarTablero (out int[,] tableroSalida, int[,] tablero, int posX, int posY,int giro);

    public bool esValida(int[,] tablero, int posX, int posY, int giro,int tamXTotal,int tamYTotal)
    {
		return dentroLimites (tamXTotal, tamYTotal, posX, posY, giro) &&
				entra (tablero, posX, posY, giro) && 
				tieneFuturoSimple (tablero, posX, posY, giro); 
			
    }

    public abstract bool entra(int[,] tablero, int posX, int posY, int giro);
	public bool dentroLimites(int tamXTotal,int tamYTotal,int posX, int posY, int giro)
    {
        int destinoX, destinoY;
        destinoPosicion(out destinoX, out destinoY, posX, posY, giro);

		return destinoX >= 0 && destinoX < tamXTotal && destinoY >= 0 && destinoY < tamYTotal;

    }
    public  bool tieneFuturoSimple(int[,] tablero, int posX, int posY, int giro)
    {
        int destinoX, destinoY;

        destinoPosicion(out destinoX, out destinoY, posX, posY, giro);

        return tablero[destinoX, destinoY] == -1;
    }

	public abstract GameObject dibujarCasilla(int casilla, GameObject dibujo,Vector3 posicion);
	
}
