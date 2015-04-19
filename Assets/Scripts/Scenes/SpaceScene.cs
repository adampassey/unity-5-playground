using UnityEngine;
using System.Collections;

public class SpaceScene : MonoBehaviour
{
	public Vector2 bounds = new Vector2 (10000, 10000);

	public int numberOfPlanets = 3;
	public int numberOfWormholes = 3;

	public Vector3 homeWormholeSpawn = new Vector3 (-100, 0, 0);

	public Galaxy galaxy;
	public GameObject planetPrefab;
	public GameObject wormholePrefab;
	public GameObject shipPrefab;
	public int numberOfShips = 3;

	public void Start ()
	{
		Universe universe = Universe.GetInstance ();
		FleetController fleetController = FleetController.GetInstance ();

		if (universe.galaxies == null) {
			galaxy = GalaxyFactory.RandomizedGalaxy (bounds, numberOfPlanets, numberOfWormholes);
			galaxy.currentGalaxy = true;

			//	also create a station on the first galaxy
			GameObject stationObject = GameObject.Instantiate (Resources.Load ("Prefabs/Station", typeof(GameObject)), new Vector3 (-500, 0, 0), Quaternion.identity) as GameObject;
			stationObject.transform.parent = galaxy.transform;

			universe.currentGalaxy = galaxy;
			universe.galaxies = galaxy;

			//	span the necessary ships
			Vector3 pos = Vector3.zero;
			Quaternion rot = new Quaternion (0, 90, -90, 0);
			for (int i = 0; i < numberOfShips; i++) {
				pos.y += i * 30;
				GameObject shipObject = GameObject.Instantiate (shipPrefab, pos, rot) as GameObject;
				Ship s = shipObject.GetComponent<Ship> ();
				s.galaxy = galaxy;
				fleetController.AddShip (s);
				if (i == 0) {
					SelectedShip selectedShip = SelectedShip.GetInstance ();
					selectedShip.Active = s;
				}

			}

		} else {
			universe.galaxies.gameObject.SetActive (true);
		}
	}
}
