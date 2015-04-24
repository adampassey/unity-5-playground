using UnityEngine;
using System.Collections;

public class LaunchButton : MonoBehaviour
{

	public void Launch ()
	{
		Debug.Log ("Launching Space Scene");

		Application.LoadLevel (Scene.SpaceScene);
	}
}
