using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Inventory.Equipment;
using Bitsy.UserInterface.Inventory.Equipment.Handler;

public class ShipEquipmentUI : EquipmentGUI {

    public static EquipmentGUI CreateComponent(GameObject parent, Equipment equipment) {
        ShipEquipmentUI equipmentGUI = parent.AddComponent<ShipEquipmentUI>();
        equipmentGUI.equipment = equipment;
        return equipmentGUI;
    }

    /**
     * 	Render the equipment GUI for each slot
    **/
    public override void OnEquipmentWindow(int windowId) {

        //	head slot
        if (equipment.IsSlotFree(EquipmentType.Head)) {
            EquipmentSlotHandler headHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Head, equipment);
            UI.Slot(new Rect(10, 55, 50, 50), new GUIStyle("button"), headHandler);
        }
        else {
            EquipmentDraggableHandler headHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Head, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Head).GetGUIContent();
            UI.Draggable(new Rect(10, 55, 50, 50), guiContent, new GUIStyle("button"), headHandler);
        }
        GUI.Label(new Rect(18, 35, 100, 100), "Flight Control");

        //	chest slot
        if (equipment.IsSlotFree(EquipmentType.Chest)) {
            EquipmentSlotHandler chestHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Chest, equipment);
            UI.Slot(new Rect(10, 130, 50, 50), new GUIStyle("button"), chestHandler);
        }
        else {
            EquipmentDraggableHandler chestHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Chest, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Chest).GetGUIContent();
            UI.Draggable(new Rect(10, 130, 50, 50), guiContent, new GUIStyle("button"), chestHandler);
        }
        GUI.Label(new Rect(18, 110, 100, 100), "Chest");

        if (draggedItem.item == null) {
            GUI.DragWindow(new Rect(0, 0, 70, 30));
        }
    }
}
