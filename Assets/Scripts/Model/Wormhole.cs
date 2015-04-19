using UnityEngine;
using System.Collections;

public class Wormhole : MonoBehaviour
{
	public enum Type
	{
		Home,
		Wormhole 
	}
	;

	public Type wormholeType = Type.Wormhole;
	public Galaxy galaxy;

	public void OnTriggerEnter2D (Collider2D collider)
	{
		Universe universe = Universe.GetInstance ();

		if (galaxy == null) {
			Debug.Log ("No Galaxy, creating a new one...");
			//	create a new galaxy
			//	and link to old one
			Galaxy newGalaxy = GalaxyFactory.RandomizedGalaxy (
				new Vector2 (10000, 10000),
				5,
				5,
				universe.currentGalaxy
			);
			//	this is the galaxy THIS wormhole points to
			galaxy = newGalaxy;
		} else {
			galaxy.gameObject.SetActive (true);
		}

		GameObject[] playerObjects = GameObject.FindGameObjectsWithTag ("Player");
		if (playerObjects != null) {
			Debug.Log ("Moving ALL ships to new wormhole.");
			foreach (Wormhole w in galaxy.Wormholes) {
				if (w.galaxy == universe.currentGalaxy) {
					Vector3 shipPos = w.gameObject.transform.position;
					shipPos.y += 100;
					shipPos.z = 0;
					foreach (GameObject g in playerObjects) {
						g.transform.position = shipPos;
						g.GetComponent<Ship> ().CurrentSpeed = 0;
						shipPos.y += 100;
					}
				}
			}
		}

		//	disable old galaxy
		Galaxy oldGalaxy = universe.currentGalaxy;

		oldGalaxy.gameObject.SetActive (false);

		universe.SetCurrentGalaxy (galaxy);
		Debug.Log (universe);
	}

	public void OnMouseDown ()
	{
		Debug.Log ("Clicked on Wormhole.");
	}
}
