using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour 
{
	public GameDirector m_gameDirector;
	public Texture2D m_texturaHabilitado;
	public Texture2D m_texturaDesHabilitado;
	public float m_velocidad;
	//public CarControleScript m_carController;

	public void Update()
	{
		/*
		if(m_carController.currentSpeed <= m_velocidad)
		{
			guiTexture.texture=m_texturaHabilitado;
		}
		else
		{
			guiTexture.texture=m_texturaDesHabilitado;
		}
		*/

	}

	public void OnMouseDown()
	{
		/*
		if(m_carController.currentSpeed <= m_velocidad)
		{
			m_gameDirector.resetScene ();
		}
		*/
		m_gameDirector.resetScene ();
	}

}
