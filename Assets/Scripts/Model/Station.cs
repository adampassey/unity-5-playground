using UnityEngine;
using System.Collections;

public class Station : MonoBehaviour
{
	public void OnTriggerEnter2D (Collider2D collider)
	{
		Ship ship = collider.gameObject.GetComponent<Ship> ();
		if (ship != null) {

			Universe universe = Universe.GetInstance ();
			universe.currentGalaxy.gameObject.SetActive (false);

			Application.LoadLevel (Scene.MainScene);
		}
	}
}
