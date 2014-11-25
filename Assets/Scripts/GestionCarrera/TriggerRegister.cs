using UnityEngine;
using System.Collections;

public class TriggerRegister : MonoBehaviour {

	public int _id;

	public int id
	{
		set { this._id = value; }
		get { return this._id; }
	}


	void OnTriggerEnter(Collider other) 
	{
		GameObject.Find ("GameDirector").SendMessage ("TriggerID", _id);
	}
}
