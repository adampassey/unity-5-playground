using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    private GameObject starmapCamera;
    private Starmap starmap;

	// Use this for initialization
	void Start () {
        starmapCamera = GameObject.FindGameObjectWithTag("MapCamera");
        starmapCamera.active = false;

        starmap = GetComponent<Starmap>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Toggling map.");

            if (starmapCamera.active) {
                starmapCamera.active = false;
            }
            else {
                starmap.Build();
                starmapCamera.active = true;
            }
        }
	}
}
