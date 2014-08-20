using UnityEngine;
using System.Collections;

public class RunAway : MonoBehaviour {

	[SerializeField]
	private GameObject runFromThis = null;

	[SerializeField]
	private float speed = 4f;


	// Use this for initialization
	void Start () {
		if (rigidbody2D == null)
			Debug.Log ("NUSGDG: Hey, this object needs a rigidbody2D to be able run away!");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D != null) {
			Vector2 direction = this.transform.position - runFromThis.transform.position;
			direction.Normalize();

			rigidbody2D.velocity = direction*speed;
		}
	}
}
