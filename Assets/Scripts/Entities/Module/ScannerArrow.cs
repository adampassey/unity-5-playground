using UnityEngine;
using System.Collections;

public class ScannerArrow : MonoBehaviour {

    public float disableAfterTime = 3f;
    public GameObject target;

    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > startTime + disableAfterTime) {
            Destroy(gameObject);
        }

        //transform.LookAt(target.transform);
	}


}
