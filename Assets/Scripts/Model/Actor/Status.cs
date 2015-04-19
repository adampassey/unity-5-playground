using UnityEngine;
using System.Collections;

public abstract class Status
{
	public int Min;
	public int Max;

	private int current;
	public int Current {
		get { return current; }
		set { 
			current = Mathf.Clamp (value, Min, Max);
		}
	}

	public Status (int min, int max, int starting)
	{
		Min = min;
		Max = max;
		Current = starting;
	}
}
