using UnityEngine;
using System.Collections;

public class GameManager 
{
	private static GameManager gm;
	private int m_semilla;
	private bool m_fijadaSemilla;
	
	private GameManager(){}

	public static GameManager getInstance()
	{
		if(gm==null)
		{
			gm= new GameManager();
		}
		return gm;
	}

	public int Semilla
	{
		get{return m_semilla;}
		set{m_semilla=value;m_fijadaSemilla=true;}
	}
	public bool SemillaFijada
	{
		get{return m_fijadaSemilla;}
		set{ m_fijadaSemilla = value;}
	}
	
}
