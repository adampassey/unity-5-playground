using UnityEngine;
using System.Collections;

public class Interior : MonoBehaviour
{
	public float triggerDistance = 10;

	private Camera camera;
	private bool visible = false;

	public void Start ()
	{
		camera = Camera.main;
		Hide ();
	}

	public void Update ()
	{
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
		Debug.Log ("Showing Interior");
		StartCoroutine (ShowCoroutine ());
	}

	public void Hide ()
	{
		Debug.Log ("Hiding Interior");
		StartCoroutine (HideCoroutine ());
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
