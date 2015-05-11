using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Starmap : MonoBehaviour {

    public GameObject galaxyPrefab;
    public GameObject linePrefab;
    private Universe universe;

    public void Start() {
        universe = Universe.GetInstance();
    }

    public void Build() {
        Debug.Log("Building starmap.");
        clearMap();
        buildGalaxy(universe.galaxies, universe.galaxies);
    }

    private void clearMap() {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in children) {
            if (child == transform) {
                continue;
            }
            Destroy(child.gameObject);
        }
    }

    private void buildGalaxy(Galaxy galaxy, Galaxy originatingGalaxy) {
        GameObject galaxyObject = GameObject.Instantiate(
            galaxyPrefab,
            galaxy.offset,
            Quaternion.identity
        ) as GameObject;

        galaxyObject.transform.parent = transform;
        galaxyObject.layer = 8;

        foreach (Wormhole wormhole in galaxy.Wormholes) {
            if (wormhole.galaxy == galaxy || wormhole.galaxy == originatingGalaxy || wormhole.galaxy == null) {
                continue;
            }

            //  draw a line to this galaxy
            GameObject lineObject = GameObject.Instantiate(
                linePrefab,
                Vector3.zero,
                Quaternion.identity
            ) as GameObject;

            lineObject.transform.parent = transform;
            lineObject.layer = 8;

            LineRenderer line = lineObject.GetComponent<LineRenderer>();
            line.SetPosition(0, galaxy.offset);
            line.SetPosition(1, wormhole.galaxy.offset);

            buildGalaxy(wormhole.galaxy, galaxy);
        }
    }
}
