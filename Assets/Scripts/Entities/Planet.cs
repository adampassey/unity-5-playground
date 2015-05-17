using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

	public Vector3 position;
	public Vector3 spin = Vector3.right;
	public int speed = 10;
    public int value = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (spin * Time.deltaTime * speed);
	}

    public void OnTriggerEnter2D(Collider2D other) {
        Ship ship = other.GetComponent<Ship>();
        if (ship == null) {
            return;
        }

        Debug.Log("Ship has collided. Beginning scan.");
        ship.scanner.ScanAnomoly(this);
    }
}
