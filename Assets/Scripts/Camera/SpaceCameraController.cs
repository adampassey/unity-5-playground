using UnityEngine;
using System.Collections;

public class SpaceCameraController : MonoBehaviour
{

	public GameObject target;
	public float minSize = 10f;
	public float maxSize = 300f;
	public bool followTarget = false;
    public float speed = 2f;

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

        Vector3 difference = target.transform.position - transform.position;
        difference.z = 0;

        transform.Translate(difference * speed * Time.deltaTime);
	}
}
