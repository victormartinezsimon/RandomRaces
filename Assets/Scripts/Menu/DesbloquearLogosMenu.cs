using UnityEngine;
using System.Collections;

public class DesbloquearLogosMenu : MonoBehaviour {

	public Logro Times10;
	public Logro Times20;

	public void OnMouseDown()
	{
		#if UNITY_EDITOR
			
		#else
			Times10.desbloquearLogro ();
			Times20.desbloquearLogro ();
		#endif

	}

}
