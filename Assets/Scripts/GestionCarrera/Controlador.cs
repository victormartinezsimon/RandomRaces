using UnityEngine;
using System.Collections;

public class Controlador : MonoBehaviour {

	public enum TipoMovimiento
	{
		Acelerar,
		Girar
	}

	public TipoMovimiento tipoMovimiento = TipoMovimiento.Acelerar;

	public float fuerza=1;

	#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY
		public void OnMultiTouch()
		{
			switch (tipoMovimiento)
			{
			case TipoMovimiento.Acelerar: CustomInput.getInstance().addVertical(fuerza);break;
			case TipoMovimiento.Girar:CustomInput.getInstance().addHorizontal(fuerza);break;
			}
		}
	#endif


	#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE
		
		void OnMouseDrag() 
		{	
			switch (tipoMovimiento)
			{
			case TipoMovimiento.Acelerar: CustomInput.getInstance().addVertical(fuerza);break;
			case TipoMovimiento.Girar:CustomInput.getInstance().addHorizontal(fuerza);break;
			}
			
		}
	#endif



}
