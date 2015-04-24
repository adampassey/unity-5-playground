using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Bitsy.UserInterface.Inventory;

public class ModuleInventory : MonoBehaviour {

    public List<GameObject> inventoryItems;

    private Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<Inventory>();
        foreach (GameObject i in inventoryItems) {
            inventory.AddObject(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!inventory.IsVisible()) {
            inventory.Show();
        }
	}
}
