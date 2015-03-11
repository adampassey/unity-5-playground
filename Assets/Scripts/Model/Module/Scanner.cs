using UnityEngine;
using System.Collections;

public class Scanner : MonoBehaviour
{

	private MeshRenderer renderer;

	void Start ()
	{
		renderer = gameObject.GetComponent<MeshRenderer> ();
		renderer.enabled = false;
	}

	public void ToggleDisplayRadius ()
	{
		if (renderer == null) {
			Debug.Log ("Scanner has no Mesh Renderer component");
			return;
		}

		renderer.enabled = renderer.enabled ? false : true;
	}

	public void Scan ()
	{
		Debug.Log ("Scanning...");
	}
}
