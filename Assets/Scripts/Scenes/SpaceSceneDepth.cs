using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpaceSceneDepth : Singleton<SpaceSceneDepth>
{
	public int depth = 0;

	private Text textUI;

	public void Start ()
	{
		GameObject go = GameObject.Find ("Canvas/Depth Text Area") as GameObject;
		textUI = go.GetComponent<Text> () as Text;
	}

	public void UpdateUI ()
	{
		if (textUI != null) {
			textUI.text = "Depth: " + depth;
		} else {
			Debug.Log ("Cannot find Depth Text Area");
		}
	}
}
