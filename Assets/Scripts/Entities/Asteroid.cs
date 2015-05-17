using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public Vector3 rotation;
    public Vector3 direction;
    public float speed;

	// Use this for initialization
	void Start () {
        rotation = new Vector3(
            Random.Range(1, 10),
            Random.Range(1, 10),
            Random.Range(1, 10)
        );

        direction = new Vector3(
            Random.Range(0, 3),
            Random.Range(0, 3),
            Random.Range(0, 3)
        );

        speed = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation * speed * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime);
	}
}
