using UnityEngine;
using System.Collections;

public class SelectedShip : Singleton<SelectedShip>
{
	
	public Ship active;
	public Ship Active {
		get { return active; }
		set { active = value; }
	}
}
