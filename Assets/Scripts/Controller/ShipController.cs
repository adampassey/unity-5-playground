using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
	public float turnDampening = 0.5f;

	private Camera camera;
	private Ship ship;

	// Use this for initialization
	void Start ()
	{
		camera = Camera.main;
		ship = gameObject.GetComponent<Ship> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (camera == null) {
			return;
		}

		if (Input.GetMouseButton (0)) {
			Vector3 pos = camera.ScreenToWorldPoint (Input.mousePosition);
			pos.z = 0;
			Debug.Log (pos);

			ship.Target = pos;
		}

		if (Input.GetKey (KeyCode.W)) {
			ship.ToggleWarp ();
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Accelerating");
			ship.Accelerate ();
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log ("Decelerating");
			ship.Decelerate ();
		}
	}
}
