using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bed : MonoBehaviour
{
	public int interval = 5;
	public int fatigueBenefit = 1;

	private List<Crew> sleepingCrew = new List<Crew> ();

	public void Start ()
	{
		StartCoroutine (sleepRoutine ());
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Crew crew = other.GetComponent<Crew> ();
		if (crew != null) {
			Debug.Log ("Crew has stepped into Bed");
			sleepingCrew.Add (crew);
		}
	}
	
	public void OnTriggerExit (Collider other)
	{
		Crew crew = other.GetComponent<Crew> ();
		if (crew != null) {
			sleepingCrew.Remove (crew);
		}
	}

	private IEnumerator sleepRoutine ()
	{
		while (true) {
			foreach (Crew c in sleepingCrew) {
				yield return null;
				Debug.Log ("Fatigue Benefit to crew: " + c.name + " of " + fatigueBenefit);
				c.fatigue.Current += fatigueBenefit;
			}
			yield return new WaitForSeconds (interval);
		}
	}
}
