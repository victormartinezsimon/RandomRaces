using UnityEngine;
using System.Collections;

public class ShowAllRecords : MonoBehaviour 
{
	public string nameScene;
    	
	void Start () 
	{
		if(Social.localUser.authenticated)
			Social.ShowLeaderboardUI();
	
		Application.LoadLevel(nameScene);
	}
    


}
