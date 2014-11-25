using UnityEngine;
using System.Collections;

public class GenerateRandom : MonoBehaviour 
{
	public GestionNumeros[] gestionesNumeros;	
	
	public void OnMouseDown()
	{
		for(int i=0;i< gestionesNumeros.Length;i++)
		{
			int valor=Random.Range (0, 10);
			int multiplicador=Random.Range(1,3);
			if(multiplicador<2) 
			{
				multiplicador=-1;
			}
			else
			{
				multiplicador=1;
			}
			int valorAPasar= valor* multiplicador;

			gestionesNumeros[i].SendMessage("UpdateDigito",valorAPasar);
		}

	}
}
