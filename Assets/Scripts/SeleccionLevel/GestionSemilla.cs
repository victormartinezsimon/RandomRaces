using UnityEngine;
using System.Collections;

public class GestionSemilla : MonoBehaviour {

	public GestionNumeros[] gestionesNumeros;


	public void OnMouseDown()
	{
		int acum = 0;

		for(int i=gestionesNumeros.Length-1;i>=0;i--)
		{
			int value = gestionesNumeros[i].getValorActual();
			acum*=10;
			acum+=value;
		}
		Debug.Log ("Semilla de: " + acum);
		GameManager gm = GameManager.getInstance ();
		gm.Semilla=acum;

		GestorRandom.deleteInstance ();
	}
}
