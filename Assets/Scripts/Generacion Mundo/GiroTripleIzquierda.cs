using UnityEngine;
using System.Collections;

public class GiroTripleIzquierda : Casilla
{

	public GiroTripleIzquierda():base(60,1){}
	
	public override void destinoGiro(out int giroDestino,int giro)
	{
		giroDestino= (giro-1 +4) % 4;
	}
	
	public override void destinoPosicion(out int X, out int Y,int actualX, int actualY,int giro)
	{
		int[] Xs={-3,2,3,-2};
		int[] Zs={2,3,-2,-3};
		
		destinoPosicion(out X,out Y,actualX, actualY,giro,Xs,Zs);
	}
	
	public override void rellenaTablero(out int[,] tableroSalida, int [,] tablero,int giro,int posX,int posY)
	{
		tableroSalida=tablero;

		int minX;
		int minZ;

		switch(giro)
		{
		default:
		case 0:minX=posX-2;minZ=posY;break;
		case 1:minX=posX;minZ=posY;break;
		case 2:minX=posX;minZ=posY-2;break;
		case 3:minX=posX-2; minZ= posY-2;break;
		}

		for(int i=0;i<3;i++)
		{
			for(int j=0;j<3;j++)
			{
				tableroSalida[minX+i,minZ+j]=-2;//para indicar que aqui no vas  
			}
		}

		tableroSalida[posX,posY]=m_decena+giro;



	}
	public override void desRellenarTablero (out int[,] tableroSalida, int[,] tablero, int posX, int posY,int giro)
	{
		tableroSalida=tablero;
		int minX;
		int minZ;
		switch(giro)
		{
		default:
		case 0:minX=posX-2;minZ=posY;break;
		case 1:minX=posX;minZ=posY;break;
		case 2:minX=posX;minZ=posY-2;break;
		case 3:minX=posX-2; minZ= posY-2;break;
		}
		
		for(int i=0;i<3;i++)
		{
			for(int j=0;j<3;j++)
			{
				tableroSalida[minX+i,minZ+j]=-1;//limpiamos
			}
		}
	}
    public override bool entra(int[,] tablero, int posX, int posY, int giro)
    {
		int minX;
		int minZ;
		switch(giro)
		{
		default:
		case 0:minX=posX-2;minZ=posY;break;
		case 1:minX=posX;minZ=posY;break;
		case 2:minX=posX;minZ=posY-2;break;
		case 3:minX=posX-2; minZ= posY-2;break;
		}

		bool devolver = true;

		for(int i=0;i<3;i++)
		{
			for(int j=0;j<3;j++)
			{
				devolver&= tablero[minX+i,minZ+j]==-1;
			}
		}


		return devolver;
    }
	public override GameObject dibujarCasilla(int casilla, GameObject dibujo,Vector3 posicion)
	{

		int giro = casilla % 10;

		float despX = dibujo.renderer.bounds.size.x * 0.33f;
		float despZ=dibujo.renderer.bounds.size.z * 0.33f;

		float posX= posicion.x;
		float posZ = posicion.z;

		switch(giro)
		{
		default:
		case 0:posX-=despX; posZ+=despZ; break;
		case 1:posX+=despX; posZ+=despZ;break;
		case 2:posX+=despX; posZ-=despZ;break;
		case 3:posX-=despX; posZ-=despZ;break;
		}

		posicion.x = posX;
		posicion.z = posZ;


		GameObject devolver = Instantiate (dibujo, posicion, Quaternion.identity) as GameObject;

		
		float grados = 180.0f + giro * 90.0f;
		devolver.transform.Rotate(0,grados,0);
		return devolver;
	}
}
