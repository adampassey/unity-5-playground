using UnityEngine;
using System.Collections;

public static class PlanetFactory
{
	//	shouldn't have to rely on ultimately
	//	maybe place in a config object in scene?
	private static string planetPrefab = "Prefabs/Planet";

	public static Planet RandomizedPlanet (Vector2 bounds, int minRadius, int maxRadius, int maxSpin)
	{
		int scale = Random.Range (minRadius, maxRadius);
		Vector3 planetPosition = new Vector3 (Random.Range (-bounds.x, bounds.x), Random.Range (-bounds.y, bounds.y), scale);
		GameObject planetObject = GameObject.Instantiate (Resources.Load (planetPrefab, typeof(GameObject)), planetPosition, Quaternion.identity) as GameObject;
		planetObject.transform.localScale = new Vector3 (scale, scale, scale);
		
		Planet planet = planetObject.GetComponent<Planet> () as Planet;
		planet.spin.y = Random.Range (-maxSpin, maxSpin);

		return planet;
	}
}
