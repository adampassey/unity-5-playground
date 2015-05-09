using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyUIText : MonoBehaviour {

    private Text text;
    private Currency currency;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        currency = Currency.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Currency: " + currency.total;
	}
}
