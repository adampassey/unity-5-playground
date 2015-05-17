using UnityEngine;
using System.Collections;

public class Scannable : MonoBehaviour {

    public float difficulty = 1f;
    public bool discovered = false;

    public void Discover() {
        discovered = true;
    }
}
