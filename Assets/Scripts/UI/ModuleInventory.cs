using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

public class ModuleInventory : MonoBehaviour {

    private Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!inventory.IsVisible()) {
            inventory.Show();
        }
	}
}
