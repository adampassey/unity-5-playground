using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterUIPanel : MonoBehaviour
{
	private SelectedCrew selectedCrew;
	private Text name;
	private Text speed;
	private Text agility;
	private Text hunger;
	private Text fatigue;


	// Use this for initialization
	void Start ()
	{
		selectedCrew = SelectedCrew.GetInstance ();
		name = GetComponent<Text> ();
		speed = transform.FindChild ("Speed").GetComponent<Text> ();
		agility = transform.FindChild ("Agility").GetComponent<Text> ();
		hunger = transform.FindChild ("Hunger").GetComponent<Text> ();
		fatigue = transform.FindChild ("Fatigue").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (selectedCrew.Active != null) {
			name.text = "Crew: #" + selectedCrew.Active.name;
			speed.text = "Speed: " + selectedCrew.Active.speed.ToString ();
			agility.text = "Agility: " + selectedCrew.Active.agility.ToString ();
			hunger.text = "Hunger: " + selectedCrew.Active.hunger.Current + "/" + selectedCrew.Active.hunger.Max;
			fatigue.text = "Fatigue: " + selectedCrew.Active.fatigue.Current + "/" + selectedCrew.Active.fatigue.Max;
		}
	}
}
