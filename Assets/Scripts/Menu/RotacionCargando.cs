using UnityEngine;
using System.Collections;

public class RotacionCargando : MonoBehaviour
{
	public Texture2D[] texturas;
	public float timeChange=0.3f;
	public float timeChangeAcum=0;
	private int texturaActual=0;

	void OnStart()
	{
		guiTexture.texture=texturas[texturaActual];
	}

	void Update()
	{
		timeChangeAcum += Time.deltaTime;
		if(timeChangeAcum>= timeChange)
		{
			texturaActual=(texturaActual+1) % texturas.Length;
			guiTexture.texture=texturas[texturaActual];
			timeChangeAcum=0;
		}
	}
}
