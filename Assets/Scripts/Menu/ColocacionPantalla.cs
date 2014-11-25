using UnityEngine;
using System.Collections;

public class ColocacionPantalla : MonoBehaviour 
{
	public Vector2 posicionPantalla;
	public Vector2 tamPantalla;
	public string nombre;

	// Use this for initialization
	void Update () 
	{
		guiTexture.pixelInset = getRectangulo ();
	}


	public Rect getRectangulo()
	{
		Rect rectangulo= new Rect(Screen.width* posicionPantalla.x,
		                          Screen.height* posicionPantalla.y,
		                          Screen.width* tamPantalla.x,
		                          Screen.height* tamPantalla.y);
		return rectangulo;
	}

}
