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
		galaxy = GalaxyFactory.RandomizedGalaxy (bounds, numberOfPlanets, numberOfWormholes);
	}
}
