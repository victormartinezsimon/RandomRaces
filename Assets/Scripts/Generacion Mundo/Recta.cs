using UnityEngine;
using System.Collections;

public class Recta : Casilla
{
	
	public Recta():base(0,1){}
	
	public override void destinoGiro(out int giroDestino,int giro)
	{
		giroDestino=giro;
	}
	
	public override void destinoPosicion(out int X, out int Y,int actualX, int actualY,int giro)
	{
		int[] Xs={0,1,0,-1};
		int[] Zs={1,0,-1,0};
		
		destinoPosicion(out X,out Y,actualX, actualY,giro,Xs,Zs);
	}
	
	public override void rellenaTablero(out int[,] tableroSalida, int [,] tablero,int giro,int posX,int posY)
	{
		tableroSalida=tablero;
		tableroSalida[posX,posY]=m_decena+giro;
	}
	public override void desRellenarTablero (out int[,] tableroSalida, int[,] tablero, int posX, int posY,int giro)
	{
		tableroSalida=tablero;
		tableroSalida[posX,posY]=-1;
	}

    public override bool entra(int[,] tablero, int posX, int posY, int giro)
    {
        return tablero[posX, posY] == -1;
    }
   
	public override GameObject dibujarCasilla(int casilla, GameObject dibujo,Vector3 posicion)
	{
		GameObject devolver = Instantiate (dibujo, posicion, Quaternion.identity) as GameObject;
		float grados = 180.0f + casilla * 90.0f;
		devolver.transform.Rotate(0,grados,0);
		return devolver;
	}
}
