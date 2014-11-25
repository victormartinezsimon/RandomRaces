using UnityEngine;
using System.Collections;

public class GestionLogros : MonoBehaviour {

	public Logro carreraAcabada;
	public Logro tiempoMenor60;
	public Logro tiempoMenor55;

	public void desbloquearLogro(float time)
	{
		carreraAcabada.desbloquearLogro ();

		if(time < 60)
		{
			tiempoMenor60.desbloquearLogro();
		}
		if(time < 55)
		{
			tiempoMenor55.desbloquearLogro();
		}
	}

}
