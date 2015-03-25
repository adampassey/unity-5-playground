using UnityEngine;
using System.Collections;

public static class GalaxyFactory
{
	//	these are temporary
	private static int minPlanetRadius = 500;
	private static int maxPlanetRadius = 1000;
	private static int maxPlanetSpin = 3;

	public static Galaxy RandomizedGalaxy (Vector2 bounds, int numberOfPlanets, int numberOfWormholes)
	{
		GameObject galaxyObject = new GameObject ();
		Galaxy galaxy = galaxyObject.AddComponent<Galaxy> ();

		for (int i = 0; i < numberOfPlanets; i++) {
			galaxy.Planets.Add (PlanetFactory.RandomizedPlanet (bounds, GalaxyFactory.minPlanetRadius, GalaxyFactory.maxPlanetRadius, GalaxyFactory.maxPlanetSpin));
		}

		for (int i = 0; i < numberOfWormholes; i++) {
			galaxy.Wormholes.Add (WormholeFactory.RandomizeWormhole (bounds));
		}
		
		return galaxy;
	}
	
}
