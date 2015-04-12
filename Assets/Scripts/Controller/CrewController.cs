using UnityEngine;
using System.Collections;

public class CrewController : MonoBehaviour
{
	public Crew[] crew;

	private SelectedCrew selectedCrew;

	// Use this for initialization
	void Start ()
	{
		crew = gameObject.GetComponentsInChildren<Crew> ();
		selectedCrew = SelectedCrew.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void MoveCrewTo (Tile tile)
	{
		Debug.Log ("Moving Crew to tile");
		Crew c = selectedCrew.Active;
		if (c != null) {
			c.MoveToTile (tile);
		}
	}
}
