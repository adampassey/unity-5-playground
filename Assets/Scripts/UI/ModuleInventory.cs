using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Bitsy.UserInterface.Inventory;

public class ModuleInventory : Inventory {

    public List<GameObject> inventoryItems;

    bool initialized = false;
	
	// Update is called once per frame
	void Update () {
        if (!initialized) {
            initialize();
        }
        if (!IsVisible()) {
            Show();
        }
	}

    private void initialize() {
        foreach (GameObject i in inventoryItems) {
            GameObject o = GameObject.Instantiate(i, Vector3.zero, Quaternion.identity) as GameObject;
            AddObject(o);
        }
        initialized = true;
    }
}
