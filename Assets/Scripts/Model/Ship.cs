using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{

	public float maxSpeed = 15f;
	public float warpSpeed = 200f;
	public float turnDampening = 10f;
	public float targetPrecision = 5f;

	private float currentSpeed = 0f;
	public float CurrentSpeed {
		get { return currentSpeed; }
		set { currentSpeed = value; }
	}

	private Vector3 target;
	public Vector3 Target {
		get { return target; }
		set {
			target = value;
			goingToTarget = true;
		}
	}

	private bool goingToTarget = false;
	private bool warping = false;
	
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
		currentSpeed ++;
		currentSpeed = Mathf.Clamp (currentSpeed, 0, maxSpeed);
	}

	public void Decelerate ()
	{
		currentSpeed --;
		currentSpeed = Mathf.Clamp (currentSpeed, 0, maxSpeed);
	}

	private void RotateTowardsTarget ()
	{
		if (!goingToTarget) {
			return;
		}

		Vector3 vectorToTarget = target - transform.position;
		Quaternion rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (vectorToTarget), turnDampening * Time.deltaTime);
		transform.rotation = rotation;

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 90);
	}
}
