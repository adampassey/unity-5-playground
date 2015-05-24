using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    public GameObject StarmapCamera;

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
            }
        }
	}

    public bool IsVisible() {
        return StarmapCamera.active;
    }

    public static bool IsMapVisible() {
        if (self == null) {
            GameObject selfGo = GameObject.Find(MapController.objectName);
            self = selfGo.GetComponent<MapController>();
        }

        return self.StarmapCamera.active;        
    }
}
