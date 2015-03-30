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
		galaxyObject.name = "Galaxy";
		Galaxy galaxy = galaxyObject.AddComponent<Galaxy> ();

		for (int i = 0; i < numberOfPlanets; i++) {
			Planet p = PlanetFactory.RandomizedPlanet (bounds, GalaxyFactory.minPlanetRadius, GalaxyFactory.maxPlanetRadius, GalaxyFactory.maxPlanetSpin);
			galaxy.Planets.Add (p);
			p.transform.parent = galaxyObject.transform;
		}

		for (int i = 0; i < numberOfWormholes; i++) {
			Wormhole w = WormholeFactory.RandomizeWormhole (bounds);
			galaxy.Wormholes.Add (w);
			w.transform.parent = galaxyObject.transform;
		}
		
		return galaxy;
	}

	public static Galaxy RandomizedGalaxy (Vector2 bounds, int numberOfPlanets, int numberOfWormholes, Galaxy galaxy)
	{
		Galaxy g = GalaxyFactory.RandomizedGalaxy (bounds, numberOfPlanets, numberOfWormholes);
		g.Wormholes [0].galaxy = galaxy;

		return g;
	}
	
}
