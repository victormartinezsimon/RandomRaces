using UnityEngine;
using System.Collections;

public class CargarSceneGoogleGames : MonoBehaviour 
{

	public string nameScene;
	public string nameSceneGoogleGames;

	public void OnMouseDown()
	{
		#if UNITY_ANDROID
		Application.LoadLevel (nameSceneGoogleGames);
		#else
		Application.LoadLevel (nameScene);
		#endif
	}
}
