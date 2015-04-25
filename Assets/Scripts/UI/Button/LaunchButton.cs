using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Bitsy.UserInterface.Inventory.Equipment;

public class LaunchButton : MonoBehaviour
{

	public void Launch ()
	{
		Debug.Log ("Launching Space Scene");

        ShipEquipment equipment = GetComponent<ShipEquipment>();
        Quaternion rot = new Quaternion(0, 90, -90, 0);
        GameObject shipPrefab = Instantiate(equipment.shipPrefab, Vector3.zero, rot) as GameObject;
        DontDestroyOnLoad(shipPrefab);
    
        //  get the ship
        Ship ship = shipPrefab.GetComponent<Ship>();
        Interior interior = ship.interior;

        //  iterate through the equipment and add
        //  them to ship
        foreach (KeyValuePair<EquipmentType, GameObject> entry in equipment.equipment) {
            EquipmentItem e = entry.Value.GetComponent<EquipmentItem>();
            switch (entry.Key) {
                case EquipmentType.Weapon :
                    interior.AddWeapon(e.prefabComponent);
                    break;
                case EquipmentType.Flight :
                    interior.AddFlightControl(e.prefabComponent);
                    break;
                case EquipmentType.Hunger :
                    interior.AddCafeteria(e.prefabComponent);
                    break;
                case EquipmentType.Fatigue :
                    interior.AddBed(e.prefabComponent);
                    break;
            }
        }

        Debug.Log("Loading Space Scene...");
		Application.LoadLevel (Scene.SpaceScene);
	}
}
