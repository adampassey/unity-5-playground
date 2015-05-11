using UnityEngine;
using System.Collections;

public class MapHoverable : MonoBehaviour {

    public string text;

    public void OnMouseOver() {
        Debug.Log("Mouse over, displaying text: " + text);
    }
}
