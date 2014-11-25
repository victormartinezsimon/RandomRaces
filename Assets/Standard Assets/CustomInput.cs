using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomInput
{
	private static CustomInput ci;

	private List<float> horizontal;
	private List<float> vertical;

	public static CustomInput getInstance()
	{
		if(ci==null)
		{
			ci= new CustomInput();
		}
		return ci;
	}

	public CustomInput()
	{
		horizontal = new List<float> ();
		vertical = new List<float> ();
	}

	public float getHorizontal()
	{
		float value;
		if(horizontal.Count != 0)
		{
			value = horizontal[0];
		}
		else
		{
			value= Input.GetAxis("Horizontal");
		}
		//Debug.Log ("Horizontal:" + value);
		return value;
	}
	public float getVertical()
	{
		float value;
		if(vertical.Count!=0)
		{
			value = vertical[0];
		}
		else
		{
			value= Input.GetAxis("Vertical");
		}
		//Debug.Log ("Vertical:" + value);
		return value;
	}

	public void addVertical(float fuerza)
	{
		vertical.Add (fuerza);
	}
	public void addHorizontal(float fuerza)
	{
		horizontal.Add (fuerza);
	}

	public void consumeInput()
	{
		if(horizontal.Count!=0)
			horizontal.RemoveAt(0);
		if(vertical.Count!=0)
			vertical.RemoveAt(0);
	}
}
