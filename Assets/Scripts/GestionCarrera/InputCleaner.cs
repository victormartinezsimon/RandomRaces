using UnityEngine;
using System.Collections;

public class InputCleaner : MonoBehaviour {

	void FixedUpdate ()
	{
		CustomInput.getInstance ().consumeInput ();
	}
}
