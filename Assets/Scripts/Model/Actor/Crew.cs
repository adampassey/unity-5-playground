using UnityEngine;
using System.Collections;

public class Crew : MonoBehaviour
{
	public string name;
	public float speed = 2;
	public float agility = 4;
	public Hunger hunger = new Hunger ();

	private SelectedCrew selectedCrew;
	private Tile targetTile;

	// Use this for initialization
	void Start ()
	{
		name = Random.Range (1, 9999).ToString ();
		selectedCrew = SelectedCrew.GetInstance ();

		//	currently randomizing crew stats
		speed = Random.Range (2, 8);
		agility = Random.Range (4, 12);

		//	this sucks to have to do
		//	essentially, in Unity, loading happens
		//	in a separate thread and invoking anything
		//	in the Unity API on this thread causes
		//	a Unity Exception. Because of this, I
		//	need to invoke the coroutine that handles
		//	the gradual increase in hunger in a Start()
		//	so it's invoked in the main thread instead
		//	of the loading thread. Needs refactor.
		hunger.Begin ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (targetTile != null) {

			Vector3 target = targetTile.transform.position;

			Quaternion rot = Quaternion.LookRotation (target - transform.position, new Vector3 (0, 0, -1));
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, agility * Time.deltaTime);

			transform.Translate (Vector3.forward * speed * Time.deltaTime);

			if (Vector3.Distance (transform.position, targetTile.transform.position) < 0.3f) {
				targetTile = null;
			}
		}
	}

	public void MoveToTile (Tile tile)
	{
		targetTile = tile;
	}

	public void OnMouseDown ()
	{
		Debug.Log ("Clicked on crew");
		selectedCrew.Active = this;
		Debug.Log ("Current hunger is: " + hunger.Current);
	}
}
