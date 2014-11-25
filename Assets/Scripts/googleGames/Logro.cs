using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Logro : MonoBehaviour 
{

	public string idLogro;
	public bool acumulativo=false;

	public void desbloquearLogro()
	{
		if(Social.localUser.authenticated)
		{
			if(!acumulativo)
			{
				Social.ReportProgress(idLogro, 100.0f, (bool success) => 
				                      {
					// handle success or failure
				});
			}
			else
			{
				((PlayGamesPlatform) Social.Active).IncrementAchievement(
					idLogro, 1, (bool success) => {
					// handle success or failure
				});
				
			}
		}
	}
	
}
