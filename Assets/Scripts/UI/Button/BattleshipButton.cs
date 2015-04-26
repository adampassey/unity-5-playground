using UnityEngine;
using System.Collections;

public class BattleshipButton : MonoBehaviour {

    public GameObject battleshipPrefab;

    public void LaunchBattleship() {
        if (battleshipPrefab == null) {
            Debug.Log("Must set battleship Prefab");
        }

        GameObject battleshipObj = Instantiate(battleshipPrefab, Vector3.zero, new Quaternion(0, 90, -90, 0)) as GameObject;
        Ship ship = battleshipObj.GetComponent<Ship>();

        Universe universe = Universe.GetInstance();
        ship.galaxy = universe.currentGalaxy;

        FleetController fleetController = FleetController.GetInstance();
        fleetController.AddShip(ship);

        SelectedShip selectedShip = SelectedShip.GetInstance();
        selectedShip.Active = ship;
    }
}
