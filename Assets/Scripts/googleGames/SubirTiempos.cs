using UnityEngine;
using System.Collections;

public class SubirTiempos : MonoBehaviour
{
	public void SubirTiempo(float time)
	{
		long timeSubir = (long)(time*1000);//paso de s a ms
		Debug.Log ("Tiempo subido de: "+timeSubir+" tiempo original de:"+ time);
		string key = getKey (GameManager.getInstance ().Semilla);
		Social.ReportScore(timeSubir, key, (bool success) => {
			// handle success or failure
		});
	}
	private string getKey(int level)
	{
		switch (level)
		{
		case 0: return "CgkI9KbknpweEAIQkgE";break;
		case 1: return "CgkI9KbknpweEAIQTg";break;
		case 2: return "CgkI9KbknpweEAIQTw";break;
		case 3: return "CgkI9KbknpweEAIQUA";break;
		case 4: return "CgkI9KbknpweEAIQUQ";break;
		case 5: return "CgkI9KbknpweEAIQUg";break;
		case 6: return "CgkI9KbknpweEAIQUw";break;
		case 7: return "CgkI9KbknpweEAIQVA";break;
		case 8: return "CgkI9KbknpweEAIQVQ";break;
		case 9: return "CgkI9KbknpweEAIQkwE";break;
		case 10: return "CgkI9KbknpweEAIQVg";break;
		case 11: return "CgkI9KbknpweEAIQVw";break;
		case 12: return "CgkI9KbknpweEAIQWA";break;
		case 13: return "CgkI9KbknpweEAIQWQ";break;
		case 14: return "CgkI9KbknpweEAIQWg";break;
		case 15: return "CgkI9KbknpweEAIQWw";break;
		case 16: return "CgkI9KbknpweEAIQXA";break;
		case 17: return "CgkI9KbknpweEAIQXQ";break;
		case 18: return "CgkI9KbknpweEAIQXg";break;
		case 19: return "CgkI9KbknpweEAIQXw";break;
		case 20: return "CgkI9KbknpweEAIQlAE";break;
		case 21: return "CgkI9KbknpweEAIQYQ";break;
		case 22: return "CgkI9KbknpweEAIQYg";break;
		case 23: return "CgkI9KbknpweEAIQYw";break;
		case 24: return "CgkI9KbknpweEAIQZA";break;
		case 25: return "CgkI9KbknpweEAIQZQ";break;
		case 26: return "CgkI9KbknpweEAIQZg";break;
		case 27: return "CgkI9KbknpweEAIQZw";break;
		case 28: return "CgkI9KbknpweEAIQaA";break;
		case 29: return "CgkI9KbknpweEAIQaQ";break;
		case 30: return "CgkI9KbknpweEAIQag";break;
		case 31: return "CgkI9KbknpweEAIQaw";break;
		case 32: return "CgkI9KbknpweEAIQbA";break;
		case 33: return "CgkI9KbknpweEAIQbQ";break;
		case 34: return "CgkI9KbknpweEAIQbg";break;
		case 35: return "CgkI9KbknpweEAIQbw";break;
		case 36: return "CgkI9KbknpweEAIQcA";break;
		case 37: return "CgkI9KbknpweEAIQcQ";break;
		case 38: return "CgkI9KbknpweEAIQcg";break;
		case 39: return "CgkI9KbknpweEAIQcw";break;
		case 40: return "CgkI9KbknpweEAIQdA";break;
		case 41: return "CgkI9KbknpweEAIQdQ";break;
		case 42: return "CgkI9KbknpweEAIQdg";break;
		case 43: return "CgkI9KbknpweEAIQdw";break;
		case 44: return "CgkI9KbknpweEAIQeA";break;
		case 45: return "CgkI9KbknpweEAIQeQ";break;
		case 46: return "CgkI9KbknpweEAIQeg";break;
		case 47: return "CgkI9KbknpweEAIQew";break;
		case 48: return "CgkI9KbknpweEAIQfA";break;
		case 49: return "CgkI9KbknpweEAIQfQ";break;
		case 50: return "CgkI9KbknpweEAIQfg";break;
		case 51: return "CgkI9KbknpweEAIQfw";break;
		case 52: return "CgkI9KbknpweEAIQgAE";break;
		case 53: return "CgkI9KbknpweEAIQgQE";break;
		case 54: return "CgkI9KbknpweEAIQggE";break;
		case 55: return "CgkI9KbknpweEAIQgwE";break;
		case 56: return "CgkI9KbknpweEAIQhAE";break;
		case 57: return "CgkI9KbknpweEAIQhQE";break;
		case 58: return "CgkI9KbknpweEAIQhgE";break;
		case 59: return "CgkI9KbknpweEAIQhwE";break;
		case 60: return "CgkI9KbknpweEAIQiAE";break;
		case 61: return "CgkI9KbknpweEAIQiQE";break;
		case 62: return "CgkI9KbknpweEAIQigE";break;
		case 63: return "CgkI9KbknpweEAIQiwE";break;
		case 64: return "CgkI9KbknpweEAIQjAE";break;
		case 65: return "CgkI9KbknpweEAIQjQE";break;
		case 66: return "CgkI9KbknpweEAIQjgE";break;
		case 67: return "CgkI9KbknpweEAIQjwE";break;
		case 68: return "CgkI9KbknpweEAIQkAE";break;
		case 69: return "CgkI9KbknpweEAIQkQE";break;
		}
		return "CgkI9KbknpweEAIQkQE";
	}
}
