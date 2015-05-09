using UnityEngine;
using System.Collections;

public class Currency : Singleton<Currency> {

    public int total = 1000;

    public void Start() {
        DontDestroyOnLoad(this);
    }
}
