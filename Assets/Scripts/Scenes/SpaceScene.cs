using UnityEngine;
using System.Collections;

public class SpaceScene : MonoBehaviour
{

	public int numberOfPlanets = 3;
	public int minPlanetRadius = 500;
	public int maxPlanetRadius = 1000;
	public int maxPlanetSpin = 3;
	public Vector2 bounds = new Vector2 (10000, 10000);

	public GameObject planetPrefab;

	public void Start ()
	{
		Randomize ();
	}

	public void Randomize ()
	{
		for (int i = 0; i < numberOfPlanets; i++) {

			int scale = Random.Range (minPlanetRadius, maxPlanetRadius);
			Vector3 planetPosition = new Vector3 (Random.Range (-bounds.x, bounds.x), Random.Range (-bounds.y, bounds.y), scale);
			GameObject planetObject = GameObject.Instantiate (planetPrefab, planetPosition, Quaternion.identity) as GameObject;
			planetObject.transform.localScale = new Vector3 (scale, scale, scale);

			Planet planet = planetObject.GetComponent<Planet> () as Planet;
			planet.spin.y = Random.Range (1, maxPlanetSpin);
		}
	}
}
