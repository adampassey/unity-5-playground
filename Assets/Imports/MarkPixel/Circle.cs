using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

    public int segments;
    public float xRadius;
    public float yRadius;
    LineRenderer line;

	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
	}

    private void CreatePoints() {
        float x, y, z = 0f, angle = 20f;

        for (int i = 0; i < (segments + 1); i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}
