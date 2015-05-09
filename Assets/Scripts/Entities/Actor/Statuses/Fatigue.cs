using UnityEngine;
using System.Collections;

public class Fatigue : TimeModifiedStatus
{
	//	ticks every 2 minutes
	public Fatigue () : base(0, 100, 100, 120)
	{
		
	}
}
