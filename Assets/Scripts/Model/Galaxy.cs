using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Galaxy : MonoBehaviour
{
	public Vector3 offset = Vector3.zero;

	public List<Wormhole> Wormholes = new List<Wormhole> ();
	public List<Planet> Planets = new List<Planet> ();
	public bool currentGalaxy = false;

	public void Start ()
	{
		gameObject.name = "Galaxy: " + Random.Range (0, 1000);
	}

	public override string ToString ()
	{
		string s = "Galaxy, offset: " + offset + "\r\n";
		foreach (Wormhole w in Wormholes) {
			s += "Wormhole at position: " + w.gameObject.transform.position + "\r\n";
			if (w.galaxy != null) {
				s += "Wormhole leads elsewhere." + "\r\n";
			}
		}
		foreach (Planet p in Planets) {
			s += "Planet at position: " + p.gameObject.transform.position + "\r\n";
		}
		if (currentGalaxy) {
			s += "Current Galaxy" + "\r\n";
		}
		s += "----------" + "\r\n";
		return s;
	}
	
}
