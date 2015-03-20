using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

	public Vector3 spin = Vector3.right;
	public int speed = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (spin * Time.deltaTime * speed);
	}
}
