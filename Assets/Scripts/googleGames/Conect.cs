using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;	

public class Conect : MonoBehaviour 
{
	public string nameSceneNext;
	public string nameScenePrev;
	// Use this for initialization
	void Start () 
	{
		GooglePlayGames.PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => 
		{
			resultadoRegistro(success);
        });
	
	}

	private void resultadoRegistro(bool success)
	{
		if(success)
		{
			Application.LoadLevel(nameSceneNext);
		}
		else
		{
			Application.LoadLevel(nameScenePrev);
		}
	}


}
