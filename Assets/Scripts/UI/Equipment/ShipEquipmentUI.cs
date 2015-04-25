using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Inventory.Equipment;
using Bitsy.UserInterface.Inventory.Equipment.Handler;

public class ShipEquipmentUI : EquipmentGUI {

    public override void Start() {
        windowRect = new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 500);
        base.Start();
    }

    public static EquipmentGUI CreateComponent(GameObject parent, Equipment equipment) {
        ShipEquipmentUI equipmentGUI = parent.AddComponent<ShipEquipmentUI>();
        equipmentGUI.equipment = equipment;
        return equipmentGUI;
    }

    public override void OnGUI() {
        windowRect = GUI.Window(gameObject.GetInstanceID(), windowRect, OnEquipmentWindow, new GUIContent(""), GUIStyle.none);
    }

    /**
     * 	Render the equipment GUI for each slot
    **/
    public override void OnEquipmentWindow(int windowId) {

        //	flight control slot
        if (equipment.IsSlotFree(EquipmentType.Flight)) {
            EquipmentSlotHandler headHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Flight, equipment);
            UI.Slot(new Rect(225, 0, 50, 50), new GUIStyle("button"), headHandler);
        }
        else {
            EquipmentDraggableHandler headHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Flight, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Flight).GetGUIContent();
            UI.Draggable(new Rect(225, 0, 50, 50), guiContent, new GUIStyle("button"), headHandler);
        }
        GUI.Label(new Rect(210, 60, 100, 100), "Flight Control");

        //	weapon slot
        if (equipment.IsSlotFree(EquipmentType.Weapon)) {
            EquipmentSlotHandler weaponHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Weapon, equipment);
            UI.Slot(new Rect(0, 200, 50, 50), new GUIStyle("button"), weaponHandler);
            UI.Slot(new Rect(450, 200, 50, 50), new GUIStyle("button"), weaponHandler);
        }
        else {
            EquipmentDraggableHandler weaponHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Weapon, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Weapon).GetGUIContent();
            UI.Draggable(new Rect(0, 200, 50, 50), guiContent, new GUIStyle("button"), weaponHandler);
            UI.Draggable(new Rect(450, 200, 50, 50), guiContent, new GUIStyle("button"), weaponHandler);
        }
        GUI.Label(new Rect(0, 260, 100, 100), "Weapon(s)");
        GUI.Label(new Rect(430, 260, 100, 100), "Weapon(s)");

        //	fatigue slot
        if (equipment.IsSlotFree(EquipmentType.Fatigue)) {
            EquipmentSlotHandler fatigueHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Fatigue, equipment);
            UI.Slot(new Rect(150, 300, 50, 50), new GUIStyle("button"), fatigueHandler);
        }
        else {
            EquipmentDraggableHandler fatigueHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Fatigue, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Fatigue).GetGUIContent();
            UI.Draggable(new Rect(150, 300, 50, 50), guiContent, new GUIStyle("button"), fatigueHandler);
        }
        GUI.Label(new Rect(130, 360, 100, 100), "Sleeping Quarters");

        //	hunger slot
        if (equipment.IsSlotFree(EquipmentType.Hunger)) {
            EquipmentSlotHandler hungerHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Hunger, equipment);
            UI.Slot(new Rect(300, 300, 50, 50), new GUIStyle("button"), hungerHandler);
        }
        else {
            EquipmentDraggableHandler hungerHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Hunger, equipment);
            GUIContent guiContent = equipment.Item(EquipmentType.Hunger).GetGUIContent();
            UI.Draggable(new Rect(300, 300, 50, 50), guiContent, new GUIStyle("button"), hungerHandler);
        }
        GUI.Label(new Rect(290, 360, 100, 100), "Mess Hall");


        if (draggedItem.item == null) {
            //GUI.DragWindow(new Rect(500, 500, 200, 300));
        }
    }
}
