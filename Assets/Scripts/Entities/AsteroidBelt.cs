using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidBelt : MonoBehaviour {

    public GameObject asteroidPrefab;
    public List<GameObject> Asteroids = new List<GameObject>();

	// Use this for initialization
	public void Build (Vector2 size, int numberOfAsteroids) {
        for (int i = 0; i < numberOfAsteroids; i++) {
            Vector3 pos = transform.position - new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y));
            GameObject asteroidObject = GameObject.Instantiate(asteroidPrefab, pos, Quaternion.identity) as GameObject;
            asteroidObject.transform.parent = transform;
            asteroidObject.transform.localScale = new Vector3(
                Random.Range(1, 75),
                Random.Range(1, 75),
                Random.Range(1, 75)
            );

            Asteroids.Add(asteroidObject);
        }
	}
}
