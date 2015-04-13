using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
	private Blaster blaster;

	private IEnumerator fireRoutine;

	// Use this for initialization
	void Start ()
	{
		blaster = gameObject.GetComponentInChildren<Blaster> ();
		fireRoutine = blaster.FireRoutine ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OnTriggerEnter (Collider other)
	{
		Crew crew = other.GetComponent<Crew> ();
		if (crew != null) {
			Debug.Log ("Turrget is crew-controlled, beginning Fire Routine");
			StartCoroutine (fireRoutine);
		}
	}
	
	public void OnTriggerExit (Collider other)
	{
		Crew crew = other.GetComponent<Crew> ();
		if (crew != null) {
			Debug.Log ("Turret is no longer crew-controlled. Stopping Fire Routine.");
			StopCoroutine (fireRoutine);
		}
	}
}
