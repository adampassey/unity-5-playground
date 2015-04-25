using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetController : Singleton<FleetController>
{

	public ArrayList ships = new ArrayList ();
	public SelectedShip selectedShip;

	private Universe universe;

	// Use this for initialization
	void Start ()
	{
		selectedShip = SelectedShip.GetInstance ();
		universe = Universe.GetInstance ();
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Debug.Log ("Selecting ALL ships");
			if (selectedShip.allShipsActive) {
				selectedShip.allShipsActive = false;
			} else {
				selectedShip.allShipsActive = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log ("Selecting ship 1");
			selectShip ((Ship)ships [0]);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log ("Selecting ship 2");
			selectShip ((Ship)ships [1]);
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Debug.Log ("Selecting ship 3");
			selectShip ((Ship)ships [2]);
		}
	}

	public void AddShip (Ship s)
	{
		ships.Add (s);
	}

	private void selectShip (Ship ship)
	{
		if (ship.galaxy == universe.currentGalaxy) {
			selectedShip.Active = ship;
		} else {
			universe.SetCurrentGalaxy (ship.galaxy);
			selectedShip.Active = ship;

			//	other ships need to hide now
			foreach (Ship s in ships) {
				if (s.galaxy == ship.galaxy)
					s.gameObject.SetActive (true);
				else
					s.gameObject.SetActive (false);
			}
		}
	}
}
