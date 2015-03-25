using UnityEngine;
using System.Collections;

public static class WormholeFactory
{

	private static string wormholePrefab = "Prefabs/Wormhole";

	public static Wormhole RandomizeWormhole (Vector2 bounds)
	{
		Vector3 wormholePosition = new Vector3 (Random.Range (-bounds.x, bounds.x), Random.Range (-bounds.y, bounds.y), 1);
		GameObject wormholeObject = GameObject.Instantiate (Resources.Load (wormholePrefab, typeof(GameObject)), wormholePosition, Quaternion.identity) as GameObject;
		
		Wormhole wormhole = wormholeObject.GetComponent<Wormhole> () as Wormhole;
		wormhole.wormholeType = Wormhole.Type.Wormhole;

		return wormhole;
	}
}
