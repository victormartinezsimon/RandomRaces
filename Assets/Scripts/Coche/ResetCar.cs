using UnityEngine;
using System.Collections;

public class ResetCar : MonoBehaviour {

	public float alturaReset;
	public Vector3 rotacionReset;
	public float maxTiempoReset;

	private float tiempoReset=0;
	private bool resetActivo=false;
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.R) && !resetActivo)
		{
			Debug.Log("Reset car");
			tiempoReset=0;
			resetActivo=true;
			transform.position= new Vector3(transform.position.x,transform.position.y+alturaReset,transform.position.z);
			transform.rotation= new Quaternion(rotacionReset.x,transform.rotation.y,rotacionReset.z,transform.rotation.w);
//			car.rotation.x=rotacionReset.x;
//			car.rotation.z=rotacionReset.z;
			
		}
		if(resetActivo)
		{
			tiempoReset+=Time.deltaTime;
			Debug.Log (tiempoReset);
			if(tiempoReset>= maxTiempoReset)
			{
				resetActivo=false;
				tiempoReset=0;
			}
		}


	}
}
