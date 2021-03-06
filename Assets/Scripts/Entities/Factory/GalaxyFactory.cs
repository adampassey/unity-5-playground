﻿using UnityEngine;
using System.Collections;

public static class GalaxyFactory
{
	//	these are temporary
	private static int minPlanetRadius = 500;
	private static int maxPlanetRadius = 1000;
	private static int maxPlanetSpin = 3;

	public static Galaxy RandomizedGalaxy (Vector2 bounds, int maxNumberOfPlanets, int maxNumberOfWormholes)
	{
		GameObject galaxyObject = new GameObject ();
		galaxyObject.name = "Galaxy";
		Galaxy galaxy = galaxyObject.AddComponent<Galaxy> ();

        int numberOfPlanets = Random.Range(0, maxNumberOfPlanets);
		for (int i = 0; i < numberOfPlanets; i++) {
			Planet p = PlanetFactory.RandomizedPlanet (bounds, GalaxyFactory.minPlanetRadius, GalaxyFactory.maxPlanetRadius, GalaxyFactory.maxPlanetSpin);
			galaxy.Planets.Add (p);
			p.transform.parent = galaxyObject.transform;
		}

        int numberOfWormholes = Random.Range(2, maxNumberOfWormholes);
		for (int i = 0; i < numberOfWormholes; i++) {
			Wormhole w = WormholeFactory.RandomizeWormhole (bounds);
			galaxy.Wormholes.Add (w);
			w.transform.parent = galaxyObject.transform;
		}

        int numberOfAsteroidBelts = Random.Range(0, 3);
        for (int i = 0; i < numberOfAsteroidBelts; i++) {
            Vector2 size = new Vector2(Random.Range(1000, 5000), Random.Range(1000, 5000));
            AsteroidBelt a = AsteroidBeltFactory.RandomizedAsteroidBelt(bounds, Random.Range(10, 500), size);
            galaxy.AsteroidBelts.Add(a);
            a.transform.parent = galaxyObject.transform;
        }

        galaxy.offset = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
		
		return galaxy;
	}

	public static Galaxy RandomizedGalaxy (Vector2 bounds, int numberOfPlanets, int numberOfWormholes, Galaxy galaxy)
	{
		Galaxy g = GalaxyFactory.RandomizedGalaxy (bounds, numberOfPlanets, numberOfWormholes);
		g.Wormholes [0].galaxy = galaxy;

		return g;
	}
	
}
