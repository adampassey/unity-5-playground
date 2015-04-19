using UnityEngine;
using System.Collections;

public class SpaceCameraController : MonoBehaviour
{

	public GameObject target;
	public float minSize = 10f;
	public float maxSize = 300f;
	public bool followTarget = false;

	private Camera spaceCamera;
	private SelectedShip selectedShip;

	void Start ()
	{
		spaceCamera = gameObject.GetComponent<Camera> ();
		selectedShip = SelectedShip.GetInstance ();
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		if (spaceCamera == null) {
			return;
		}

		if (selectedShip.Active == null) {
			return;
		}

		target = selectedShip.Active.gameObject;

		transform.LookAt (target.transform.position);
		GetScrollWheelInput ();
		FollowTarget ();

	}

	private void GetScrollWheelInput ()
	{

		float wheelDelta = Input.GetAxis ("Mouse ScrollWheel");
		
		if (!wheelDelta.Equals (0f)) {
			spaceCamera.orthographicSize = spaceCamera.orthographicSize - spaceCamera.orthographicSize * wheelDelta;
			spaceCamera.orthographicSize = Mathf.Clamp (spaceCamera.orthographicSize, minSize, maxSize);
		}
	}

	private void FollowTarget ()
	{
		if (!followTarget) {
			return;
		}

		Vector3 pos = transform.position;
		pos.x = target.transform.position.x;
		pos.y = target.transform.position.y;

		transform.position = pos;
	}
}
