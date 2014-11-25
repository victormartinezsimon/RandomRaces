using UnityEngine;
using System.Collections;

public class CargarScene : MonoBehaviour {

	public string nameScene;

	public void OnMouseDown()
	{
		cargaNormal();
	}

	private void cargaNormal()
	{
		Application.LoadLevel (nameScene);
	}

}
