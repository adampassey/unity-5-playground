using UnityEngine;
using System.Collections;

public class Hunger : TimeModifiedStatus
{
	//	ticks every 1 minutes
	public Hunger () : base(0, 100, 100, 60)
	{

	}
}
