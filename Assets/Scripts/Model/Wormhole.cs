using UnityEngine;
using System.Collections;

public class Wormhole : MonoBehaviour
{

	public void OnTriggerEnter2D (Collider2D collider)
	{
		Ship ship = collider.gameObject.GetComponent<Ship> ();
		if (ship != null) {
			Application.LoadLevel (Scene.MainScene);
		}
	}

	public void OnMouseDown ()
	{
		Debug.Log ("Clicked on Wormhole.");
	}
}
