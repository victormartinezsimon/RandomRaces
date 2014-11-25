using UnityEngine;
using System.Collections;

public class MultiTouch : MonoBehaviour {

	public ColocacionPantalla[] m_objectosSeleccionables;
	public GUIText texto;
	
	// Update is called once per frame
	void Update () 
	{
		Touch[] touches = Input.touches;

		if(Input.touchCount!=0)
		{
			texto.text="";
			for(int i=0; i< Input.touchCount;i++)
			{
				Vector2 posicion= touches[i].position;
				for(int j=0; j< m_objectosSeleccionables.Length;j++)
				{
					Rect rectangulo= m_objectosSeleccionables[j].getRectangulo();
					
					if(rectangulo.Contains(posicion))
					{
						//m_objectosSeleccionables[j].SendMessageUpwards("OnMultiTouch");
						m_objectosSeleccionables[j].SendMessage("OnMultiTouch");
						
						texto.text+=m_objectosSeleccionables[j].nombre+",";
					}
				}
			}
		}
	}
}
