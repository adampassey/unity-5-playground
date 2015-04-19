using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetController : Singleton<FleetController>
{

	ArrayList ships = new ArrayList ();
	SelectedShip selectedShip;

	// Use this for initialization
	void Start ()
	{
		selectedShip = SelectedShip.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Debug.Log ("Selecting ALL ships");
			//	TODO: all ships!
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log ("Selecting ship 1");
			selectedShip.Active = (Ship)ships [0];
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log ("Selecting ship 2");
			selectedShip.Active = (Ship)ships [1];
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Debug.Log ("Selecting ship 3");
			selectedShip.Active = (Ship)ships [2];
		}
	}

	public void AddShip (Ship s)
	{
		ships.Add (s);
	}
}
