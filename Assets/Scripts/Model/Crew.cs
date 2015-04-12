using UnityEngine;
using System.Collections;

public class Crew : MonoBehaviour
{
	public float speed = 2;
	public float agility = 4;

	private SelectedCrew selectedCrew;
	private Tile targetTile;

	// Use this for initialization
	void Start ()
	{
		selectedCrew = SelectedCrew.GetInstance ();
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
	}
}
