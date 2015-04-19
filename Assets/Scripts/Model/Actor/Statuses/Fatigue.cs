using UnityEngine;
using System.Collections;

public class Fatigue : TimeModifiedStatus
{
	//	ticks every 15 minutes
	public Fatigue () : base(0, 100, 100, 900)
	{
		
	}
}
