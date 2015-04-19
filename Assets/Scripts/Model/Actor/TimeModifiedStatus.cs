using UnityEngine;
using System.Collections;

public abstract class TimeModifiedStatus : Status
{
	public float Interval;
	private IEnumerator intervalRoutine;
	private RoutineRunner routineRunner;

	public TimeModifiedStatus (int min, int max, int starting, float interval) : base(min, max, starting)
	{
		Interval = interval;
		routineRunner = RoutineRunner.GetInstance ();
		routineRunner.StartCoroutine (modifyStatusRoutine ());
	}
	
	private IEnumerator modifyStatusRoutine ()
	{
		while (true) {
			yield return new WaitForSeconds (Interval);
			Current -= 1;
		}
	}
}
