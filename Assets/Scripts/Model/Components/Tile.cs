﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	CrewController crewController;

	// Use this for initialization
	void Start ()
	{
		crewController = gameObject.GetComponentInParent<CrewController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnMouseDown ()
	{
		Debug.Log ("Tile clicked on");
		crewController.MoveCrewTo (this);
	}
}
