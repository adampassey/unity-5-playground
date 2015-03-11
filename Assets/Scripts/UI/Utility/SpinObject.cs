using UnityEngine;
using System.Collections;

public class SpinObject : MonoBehaviour
{

	public GameObject obj;
	public Vector3 rotation;
	public float speed;
	
	// Update is called once per frame
	void Update ()
	{
		obj.transform.Rotate (rotation * Time.deltaTime * speed);
	}
}
