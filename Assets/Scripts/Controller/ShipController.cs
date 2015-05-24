using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
	public float turnDampening = 0.5f;

	private Camera camera;
	private Ship ship;
	private SelectedShip selectedShip;
	private Universe universe;

	// Use this for initialization
	void Start ()
	{
		camera = Camera.main;
		ship = gameObject.GetComponent<Ship> ();
		selectedShip = SelectedShip.GetInstance ();
		universe = Universe.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (camera == null) {
            camera = Camera.main;
		}

		if (selectedShip.Active != ship && !selectedShip.allShipsActive) {
			return;
		}

		if (selectedShip.allShipsActive && universe.currentGalaxy != ship.galaxy) {
			return;
		}

        if (MapController.IsMapVisible()) {
            return;
        }

		if (Input.GetMouseButton (0)) {
			Vector3 pos = camera.ScreenToWorldPoint (Input.mousePosition);
			pos.z = 0;

			ship.Target = pos;
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			ship.ToggleWarp ();
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			ship.Accelerate ();
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			ship.Decelerate ();
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			ship.scanner.ToggleDisplayRadius ();
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			ship.scanner.Scan ();
		}
	}
}
