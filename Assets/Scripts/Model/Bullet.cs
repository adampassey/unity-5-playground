using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public float speed = 10f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	public void OnTriggerEnter (Collider other)
	{
		// For now, it just gets destroyed
		Destroy (gameObject);
	}
}
