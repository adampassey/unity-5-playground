using UnityEngine;
using System.Collections;

public class SpaceButton : MonoBehaviour {

    public void GoToSpace() {
        Application.LoadLevel(Scene.SpaceScene);
    }
}
