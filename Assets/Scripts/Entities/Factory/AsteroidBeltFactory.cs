using UnityEngine;
using System.Collections;

public class AsteroidBeltFactory : MonoBehaviour {

    public static string prefabPath = "Prefabs/Asteroid Belt";

    public static AsteroidBelt RandomizedAsteroidBelt(Vector2 bounds, int numberOfAsteroids, Vector2 size) {
        GameObject asteroidBeltObject = GameObject.Instantiate(
            Resources.Load(prefabPath),
            new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y), 0),
            Quaternion.identity
        ) as GameObject;

        AsteroidBelt asteroidBelt = asteroidBeltObject.GetComponent<AsteroidBelt>();
        asteroidBelt.Build(size, numberOfAsteroids);

        return asteroidBelt;
    }
}
