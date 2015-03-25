using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T GetInstance ()
	{
		if (instance == null) {
			GameObject go = new GameObject ();
			instance = go.AddComponent<T> ();
		}
		return instance;
	}
}
