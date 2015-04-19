using UnityEngine;
using System.Collections;

public class FlightControl : MonoBehaviour
{

	private Ship ship;

	// Use this for initialization
	void Start ()
	{
		ship = gameObject.GetComponentInParent<Ship> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnTriggerEnter (Collider other)
	{
		Crew crew = other.GetComponent<Crew> ();
		if (crew != null) {
			Debug.Log ("Ship is now being piloted.");
			if (ship == null) {
				Debug.Log ("Trying to pilot ship, but ship is null...");
			}
			ship.piloted = true;
		}
	}

	public void OnTriggerExit (Collider other)
	{
		Debug.Log ("Ship is no longer being piloted.");
		ship.piloted = false;
	}
}
