using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{

	public float maxSpeed = 15f;
	public float warpSpeed = 200f;
	public float turnDampening = 10f;
	public float targetPrecision = 5f;
	public Scanner scanner;
	public Interior interior;
	public bool piloted = true;
	public Galaxy galaxy;

	private float currentSpeed = 0f;
	public float CurrentSpeed {
		get { return currentSpeed; }
		set { currentSpeed = value; }
	}

	private Vector3 target;
	public Vector3 Target {
		get { return target; }
		set {
			if (!piloted || warping) {
				return;
			}
			target = value;
			goingToTarget = true;
		}
	}
	
	private bool goingToTarget = false;
	private bool warping = false;

	void Start ()
	{
		scanner = gameObject.GetComponentInChildren<Scanner> ();
		interior = gameObject.GetComponentInChildren<Interior> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target != null && Vector3.Distance (transform.position, target) <= targetPrecision) {
			goingToTarget = false;

			if (warping) {
				ToggleWarp ();
			}
		}

		RotateTowardsTarget ();
		transform.Translate (Vector3.forward * currentSpeed * Time.deltaTime);
	}

	public void ToggleWarp ()
	{
		if (warping) {
			warping = false;
			currentSpeed = maxSpeed;
		} else {
			warping = true;
			currentSpeed = warpSpeed; 
		}
	}

	public void Accelerate ()
	{
		if (!piloted) {
			return;
		}

		currentSpeed ++;
		currentSpeed = Mathf.Clamp (currentSpeed, 0, maxSpeed);
	}

	public void Decelerate ()
	{
		if (!piloted) {
			return;
		}

		currentSpeed --;
		currentSpeed = Mathf.Clamp (currentSpeed, 0, maxSpeed);
	}

	private void RotateTowardsTarget ()
	{
		if (!piloted || !goingToTarget) {
			return;
		}

		Quaternion rot = Quaternion.LookRotation (target - transform.position, new Vector3 (0, 0, -1));
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, turnDampening * Time.deltaTime);
	}
}
