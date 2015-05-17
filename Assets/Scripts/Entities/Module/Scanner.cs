using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scanner : MonoBehaviour
{
    public float ScannerStrength = 0.1f;
    public float ScannerRange = 5000f;

	private MeshRenderer renderer;
    private Currency currency;
    private Ship ship;

    //  display the direction of scanned
    //  objects
    private GameObject arrowPrefab;
    private static string arrowPath = "Prefabs/Arrow (Placeholder)";
    private static string arrowName = "Arrow";

	void Start ()
	{
		renderer = gameObject.GetComponent<MeshRenderer> ();
		renderer.enabled = false;
        currency = Currency.GetInstance();

        ship = gameObject.GetComponentInParent<Ship>();

        arrowPrefab = Resources.Load(arrowPath) as GameObject;
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

        Universe universe = Universe.GetInstance();
        Galaxy galaxy = universe.currentGalaxy;

        //  remove all arrows
        Transform[] arrows = ship.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in arrows) {
            if (t.gameObject.name == arrowName) {
                Destroy(t.gameObject);
            }
        }

        List<Scannable> scannables = new List<Scannable>();

        foreach (Planet p in galaxy.Planets) {
            if (p.GetComponent<Scannable>().discovered) {
                continue;
            }
            scannables.Add(p.GetComponent<Scannable>());
        }

        foreach (Wormhole w in galaxy.Wormholes) {
            scannables.Add(w.GetComponent<Scannable>());
        }

        foreach (Scannable s in scannables) {

            //  create a new arrow (at the ships location)
            GameObject arrow = GameObject.Instantiate(arrowPrefab, ship.transform.position, Quaternion.identity) as GameObject;
            arrow.transform.parent = ship.transform;
            arrow.transform.position = ship.transform.position;
            arrow.name = arrowName;

            arrow.transform.LookAt(s.transform);
            arrow.transform.Translate(Vector3.forward * 50);

            ScannerArrow scannerArrow = arrow.GetComponent<ScannerArrow>();
            scannerArrow.target = s.gameObject;
        }
	}

    public void ScanAnomoly(Planet planet) {
        currency.total += planet.value * Universe.GetInstance().currentGalaxy.depth;
        planet.GetComponent<Scannable>().Discover();
    }
}
