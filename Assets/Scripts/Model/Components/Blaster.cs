using UnityEngine;
using System.Collections;

public class Blaster : MonoBehaviour
{
	public GameObject target;
	public GameObject bulletPrefab;
	public float fireDelay = 3f;

	public void OnTriggerEnter (Collider other)
	{
		Ship ship = other.gameObject.GetComponent<Ship> ();
		if (ship != null) {
			Debug.Log ("Ship targetable.");
			target = ship.gameObject;
		}
	}
	
	public void OnTriggerExit (Collider other)
	{
		Debug.Log ("Lost target.");
		target = null;
	}

	public IEnumerator FireRoutine ()
	{
		while (true) {
			if (target != null) {
				Debug.Log ("Firing!");
				Fire ();
			}
			yield return new WaitForSeconds (fireDelay);
		}
	}

	private void Fire ()
	{
		GameObject bullet = GameObject.Instantiate (bulletPrefab, transform.position, Quaternion.identity) as GameObject;
		bullet.transform.LookAt (target.transform.position);
	}
}
