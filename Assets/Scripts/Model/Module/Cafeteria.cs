using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cafeteria : MonoBehaviour
{
	public int interval = 5;
	public int hungerBenefit = 1;
	
	private List<Crew> crew = new List<Crew> ();
	
	public void Start ()
	{
		StartCoroutine (eatRoutine ());
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Crew c = other.GetComponent<Crew> ();
		if (c != null) {
			Debug.Log ("Crew has stepped into Cafeteria");
			crew.Add (c);
		}
	}
	
	public void OnTriggerExit (Collider other)
	{
		Crew c = other.GetComponent<Crew> ();
		if (c != null) {
			crew.Remove (c);
		}
	}
	
	private IEnumerator eatRoutine ()
	{
		while (true) {
			foreach (Crew c in crew) {
				yield return null;
				Debug.Log ("Hunger Benefit to crew: " + c.name + " of " + hungerBenefit);
				c.hunger.Current += hungerBenefit;
			}
			yield return new WaitForSeconds (interval);
		}
	}
}
