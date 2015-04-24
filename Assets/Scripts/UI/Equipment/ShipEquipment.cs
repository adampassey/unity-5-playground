using UnityEngine;
using System.Collections;

using Bitsy.UserInterface.Inventory.Equipment;

public class ShipEquipment : Equipment {

    public override EquipmentGUI CreateEquipmentUI() {
        return ShipEquipmentUI.CreateComponent(equipmentContainer, this);
    }
}
