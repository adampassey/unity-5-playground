using UnityEngine;
using System.Collections;

public class SpaceScene : MonoBehaviour
{
	public Vector2 bounds = new Vector2 (10000, 10000);

	public int numberOfPlanets = 3;
	public int minPlanetRadius = 500;
	public int maxPlanetRadius = 1000;
	public int maxPlanetSpin = 3;

	public int numberOfWormholes = 3;

	public Vector3 homeWormholeSpawn = new Vector3 (-100, 0, 0);

	public GameObject planetPrefab;
	public GameObject wormholePrefab;

	public void Start ()
	{
		Randomize ();
	}

	public void Randomize ()
	{
		//	create celestials
		RandomizeCelestials ();

		//	create other wormholes
		RandomizeWormholes ();

		//	create home wormhole (takes you back to main menu)
		GameObject homeWormholeObject = GameObject.Instantiate (wormholePrefab, homeWormholeSpawn, Quaternion.identity) as GameObject;
		Wormhole homeWormhole = homeWormholeObject.GetComponent<Wormhole> () as Wormhole;
		homeWormhole.wormholeType = Wormhole.Type.Home;
	}

	private void RandomizeCelestials ()
	{
		for (int i = 0; i < numberOfPlanets; i++) {
			int scale = Random.Range (minPlanetRadius, maxPlanetRadius);
			Vector3 planetPosition = new Vector3 (Random.Range (-bounds.x, bounds.x), Random.Range (-bounds.y, bounds.y), scale);
			GameObject planetObject = GameObject.Instantiate (planetPrefab, planetPosition, Quaternion.identity) as GameObject;
			planetObject.transform.localScale = new Vector3 (scale, scale, scale);
			
			Planet planet = planetObject.GetComponent<Planet> () as Planet;
			planet.spin.y = Random.Range (-maxPlanetSpin, maxPlanetSpin);
		}
	}

	private void RandomizeWormholes ()
	{
		for (int i = 0; i < numberOfWormholes; i++) {
			Vector3 wormholePosition = new Vector3 (Random.Range (-bounds.x, bounds.x), Random.Range (-bounds.y, bounds.y), 1);
			GameObject wormholeObject = GameObject.Instantiate (wormholePrefab, wormholePosition, Quaternion.identity) as GameObject;

			Wormhole wormhole = wormholeObject.GetComponent<Wormhole> () as Wormhole;
			wormhole.wormholeType = Wormhole.Type.Wormhole;
		}
	}
}
