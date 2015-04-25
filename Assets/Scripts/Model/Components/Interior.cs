using UnityEngine;
using System.Collections;

public class Interior : MonoBehaviour
{
	public float triggerDistance = 10;

	private Camera camera;
	private ShipController shipController;
	private CrewController crewController;
	private bool visible = false;

	public void Start ()
	{
		camera = Camera.main;
		shipController = gameObject.GetComponentInParent<ShipController> ();
		crewController = gameObject.GetComponent<CrewController> ();

		Hide ();
	}

	public void Update ()
	{
        if (camera == null) {
            camera = Camera.main;
        }

		if (visible && camera.orthographicSize > triggerDistance) {
			Hide ();
			visible = false;
		} else if (!visible && camera.orthographicSize < triggerDistance) {
			Show ();
			visible = true;
		}
	}

	public void Show ()
	{
		StartCoroutine (ShowCoroutine ());
		shipController.enabled = false;
		crewController.enabled = true;
	}

	public void Hide ()
	{
		StartCoroutine (HideCoroutine ());
		shipController.enabled = true;
		crewController.enabled = false;
	}

    public void AddFlightControl(GameObject flightControl) {
        flightControl = (GameObject) Instantiate(flightControl, Vector3.zero, new Quaternion(90, -90, 0, 0));
        flightControl.transform.parent = transform;
        flightControl.transform.localPosition = new Vector3(0, 4, 8);
    }

    public void AddWeapon(GameObject weapon) {
        GameObject weaponOne = (GameObject)Instantiate(weapon, Vector3.zero, new Quaternion(0, 0, 0, 0));
        weaponOne.transform.parent = transform;
        weaponOne.transform.localPosition = new Vector3(-6.5f, 4.5f, 0);

        GameObject weaponTwo = (GameObject)Instantiate(weapon, Vector3.zero, new Quaternion(0, -180, 0, 0));
        weaponTwo.transform.parent = transform;
        weaponTwo.transform.localPosition = new Vector3(6.5f, 4.5f, 0);
    }

    public void AddBed(GameObject bed) {
        bed = (GameObject)Instantiate(bed, Vector3.zero, new Quaternion(90, 90, 0, 0));
        bed.transform.parent = transform;
        bed.transform.localPosition = new Vector3(-2, 4, -2);
    }

    public void AddCafeteria(GameObject cafeteria) {
        cafeteria = (GameObject)Instantiate(cafeteria, Vector3.zero, new Quaternion(90, 90, 0, 0));
        cafeteria.transform.parent = transform;
        cafeteria.transform.localPosition = new Vector3(2, 4, -2);
    }

	private IEnumerator ShowCoroutine ()
	{
		Transform[] children = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform child in children) {
			Renderer renderer = child.GetComponent<Renderer> ();
			if (renderer != null) {
				renderer.enabled = true;
			}
			yield return null;
		}
	}

	private IEnumerator HideCoroutine ()
	{
		Transform[] children = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform child in children) {
			Renderer renderer = child.GetComponent<Renderer> ();
			if (renderer != null) {
				renderer.enabled = false;
			}
			yield return null;
		}
	}
}
