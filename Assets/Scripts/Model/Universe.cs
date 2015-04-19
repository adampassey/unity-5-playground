using UnityEngine;
using System.Collections;

public class Universe : Singleton<Universe>
{
	public Galaxy galaxies;
	public Galaxy currentGalaxy;

	public void Start ()
	{
		DontDestroyOnLoad (this);
	}

	//	Wow! this is DISGUSTING
	public void SetCurrentGalaxy (Galaxy galaxy)
	{
		currentGalaxy.gameObject.SetActive (false);
		currentGalaxy.currentGalaxy = false;
		currentGalaxy = galaxy;

		galaxy.currentGalaxy = true;
		galaxy.gameObject.SetActive (true);
	}

	public override string ToString ()
	{
		return "Galaxy Beginning: " + galaxies;
	}
}
