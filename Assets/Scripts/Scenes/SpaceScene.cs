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

	public void Start ()
	{
		Universe universe = Universe.GetInstance ();

		if (universe.galaxies == null) {
			galaxy = GalaxyFactory.RandomizedGalaxy (bounds, numberOfPlanets, numberOfWormholes);
			galaxy.currentGalaxy = true;

			//	also create a station on the first galaxy
			GameObject stationObject = GameObject.Instantiate (Resources.Load ("Prefabs/Station", typeof(GameObject)), new Vector3 (-100, 0, 0), Quaternion.identity) as GameObject;
			stationObject.transform.parent = galaxy.transform;

			universe.currentGalaxy = galaxy;
			universe.galaxies = galaxy;
		} else {
			universe.galaxies.gameObject.SetActive (true);
		}
	}
}
