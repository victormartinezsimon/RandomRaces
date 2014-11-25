using UnityEngine;
using System.Collections;

public class GestionFlecha : MonoBehaviour 
{

	public int suma;
	public GameObject texto;

	public void OnMouseDown()
	{
		texto.SendMessage ("UpdateDigito",suma);

	}

}
