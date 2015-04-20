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
		}

		Ship ship = collider.gameObject.GetComponent<Ship> ();
		if (ship != null) {
			foreach (Wormhole w in galaxy.Wormholes) {
				if (w.galaxy == universe.currentGalaxy) {
					Vector3 shipPos = w.gameObject.transform.position;
					shipPos.y += 100;
					shipPos.z = 0;
					ship.transform.position = shipPos;
					ship.CurrentSpeed = 0;
				}
			}
			ship.galaxy = galaxy;
		}

		//	disable old galaxy
		//	if this ship is the one being controlled
		SelectedShip selectedShip = SelectedShip.GetInstance ();
		if (ship == selectedShip.Active) {
			Galaxy oldGalaxy = universe.currentGalaxy;

			oldGalaxy.gameObject.SetActive (false);
			galaxy.gameObject.SetActive (true);

			universe.SetCurrentGalaxy (galaxy);
			Debug.Log (universe);

			//	make sure all other ships in this
			//	galaxy are displayed
			FleetController fleetController = FleetController.GetInstance ();
			foreach (Ship s in fleetController.ships) {
				if (s.galaxy == galaxy) {
					s.gameObject.SetActive (true);
				} else {
					s.gameObject.SetActive (false);
				}
			}

		} else {
			ship.gameObject.SetActive (false);
		}
	}

	public void OnMouseDown ()
	{
		Debug.Log ("Clicked on Wormhole.");
	}
}
