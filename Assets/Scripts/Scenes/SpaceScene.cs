using UnityEngine;
using System.Collections;

public class SpaceScene : MonoBehaviour
{
	public Vector2 bounds = new Vector2 (50000, 50000);

	public int numberOfPlanets = 3;
	public int numberOfWormholes = 3;

	public Vector3 homeWormholeSpawn = new Vector3 (-100, 0, 0);

	public Galaxy galaxy;
	public GameObject planetPrefab;
	public GameObject wormholePrefab;
	public GameObject shipPrefab;
    public GameObject starmapPrefab;
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
  
		} else {
			universe.galaxies.gameObject.SetActive (true);
		}

        GameObject[] ships = GameObject.FindGameObjectsWithTag("Player");
        if (ships.Length > 0) {
            foreach (GameObject ship in ships) {
                Debug.Log(ship.name);
                Ship s = ship.GetComponent<Ship>();
                if (s == null) {
                    Debug.Log("No ship component on this thing");   
                }

                //  this ship hasn't already
                //  been flown
                if (!s.galaxy) {
                    s.galaxy = universe.currentGalaxy;
                    fleetController.AddShip(s);

                    SelectedShip selectedShip = SelectedShip.GetInstance();
                    selectedShip.Active = s;
                }
            }
        }
        else {

            //  spawn the necessary ship(s) as none
            //  were launched
            Vector3 pos = Vector3.zero;
            Quaternion rot = new Quaternion(0, 90, -90, 0);
            for (int i = 0; i < numberOfShips; i++) {
                pos.y += i * 30;
                GameObject shipObject = GameObject.Instantiate(shipPrefab, pos, rot) as GameObject;
                Ship s = shipObject.GetComponent<Ship>();
                s.galaxy = galaxy;
                fleetController.AddShip(s);
                if (i == 0) {
                    SelectedShip selectedShip = SelectedShip.GetInstance();
                    selectedShip.Active = s;
                }

            }
        }

        //  instantiate the starmap
        GameObject.Instantiate(starmapPrefab, Vector3.zero, Quaternion.identity);

	}
}
