using UnityEngine;
using System.Collections;

public class GestionNumeros : MonoBehaviour {

	public Texture2D[] texturas;//del 0 al 9
	public int valorActual = 0;
	public int maximo=10;

	void OnStart()
	{
		dibujarNumero ();
	}
	
	// Update is called once per frame
	void UpdateDigito (int suma) 
	{
		valorActual = (valorActual + suma +maximo) % maximo;
		if(valorActual<0)
		{
			valorActual= (valorActual*-1) %maximo;
		}
		dibujarNumero ();
	}

	public int getValorActual()
	{
		return valorActual;
	}

	private void dibujarNumero()
	{

		guiTexture.texture= texturas [valorActual];

	}
}
