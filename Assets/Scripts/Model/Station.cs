using UnityEngine;
using System.Collections;

public class Station : MonoBehaviour
{
	public void OnTriggerEnter2D (Collider2D collider)
	{
		Ship ship = collider.gameObject.GetComponent<Ship> ();
		if (ship != null) {
			Application.LoadLevel (Scene.MainScene);
		}
	}
}
