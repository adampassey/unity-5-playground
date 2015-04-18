using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterUIPanel : MonoBehaviour
{
	private SelectedCrew selectedCrew;
	private Text name;
	private Text speed;
	private Text agility;


	// Use this for initialization
	void Start ()
	{
		selectedCrew = SelectedCrew.GetInstance ();
		name = GetComponent<Text> ();
		speed = transform.FindChild ("Speed").GetComponent<Text> ();
		agility = transform.FindChild ("Agility").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (selectedCrew.Active != null) {
			name.text = "Crew: #" + selectedCrew.Active.name;
			speed.text = "Speed: " + selectedCrew.Active.speed.ToString ();
			agility.text = "Agility: " + selectedCrew.Active.agility.ToString ();
		}
	}
}
