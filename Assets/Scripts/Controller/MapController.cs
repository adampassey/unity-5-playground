using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

    public GameObject StarmapCamera;
    public float cameraSpeed = 2;

    private Starmap starmap;

    private static MapController self;
    private static string cameraName = "MapCamera";
    private static string objectName = "Starmap";

	// Use this for initialization
	void Start () {
        StarmapCamera = GameObject.FindGameObjectWithTag(MapController.cameraName);
        StarmapCamera.active = false;

        starmap = GetComponent<Starmap>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Toggling map.");

            if (StarmapCamera.active) {
                StarmapCamera.active = false;
            }
            else {
                starmap.Build();
                StarmapCamera.active = true;

                //  focus on the first star
                //  because the current system
                //  isn't easy to reach
                transform.LookAt(starmap.galaxies[0].transform);
            }
        }

        if (!StarmapCamera.active) {
            return;
        }

        //  control the map camera
        if (Input.GetKey(KeyCode.Mouse0)) {
            Debug.Log("Mouse!");
            transform.RotateAroundLocal(
               new Vector3(
                   Input.GetAxis("Mouse Y"),
                   - Input.GetAxis("Mouse X"),
                   0
                ), 
                cameraSpeed * Time.deltaTime
            );
        }

	}

    public static bool IsMapVisible() {
        if (self == null) {
            GameObject selfGo = GameObject.Find(MapController.objectName);
            self = selfGo.GetComponent<MapController>();
        }

        return self.StarmapCamera.active;        
    }
}
