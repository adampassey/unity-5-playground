using UnityEngine;
using System.Collections;

public class Scanner : MonoBehaviour
{

	private MeshRenderer renderer;
    private Currency currency;

	void Start ()
	{
		renderer = gameObject.GetComponent<MeshRenderer> ();
		renderer.enabled = false;
        currency = Currency.GetInstance();
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

    public void ScanAnomoly(Planet planet) {
        currency.total += planet.value;
        planet.Discover();
    }
}
