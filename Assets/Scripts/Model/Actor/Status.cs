using UnityEngine;
using System.Collections;

public abstract class Status
{
	public int Min;
	public int Max;
	public int Current;

	public Status (int min, int max, int starting)
	{
		Min = min;
		Max = max;
		Current = starting;
	}
}
