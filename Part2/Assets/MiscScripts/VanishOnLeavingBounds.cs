using UnityEngine;
using System.Collections;

public class VanishOnLeavingBounds : MonoBehaviour {

    [SerializeField]
    private float minY;


	// Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) Destroy(this.gameObject);
	}

    void OnDrawGizmos()
    {
        var lineStartPoint = new Vector3(-50f, minY, 0f);
        var lineEndPoint = new Vector3(50f, minY, 0f);
        Gizmos.DrawLine(lineStartPoint, lineEndPoint);
    }
}
