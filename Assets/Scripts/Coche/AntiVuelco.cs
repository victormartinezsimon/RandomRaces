using UnityEngine;
using System.Collections;

public class AntiVuelco : MonoBehaviour
{
	public float maximosGrados=45;
	public float nuevoGrado=40;

	
	// Update is called once per frame
	void Update () 
	{
		float anguloZ = transform.eulerAngles.z;
		if(anguloZ< maximosGrados*-1)
		{
			Debug.Log("Menor");
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, nuevoGrado*-1);
		}
		if(anguloZ> maximosGrados)
		{
			Debug.Log("mayor");
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, nuevoGrado);
		}
		Debug.Log (transform.eulerAngles.z);
	}
}
