using UnityEngine;
using System.Collections;

public class RunAway : MonoBehaviour {

	[SerializeField]
	private GameObject runFromThis;

	[SerializeField]
	private float speed = 4f;


	// Use this for initialization
	void Start () {
		if (rigidbody2D == null)
			Debug.Log ("NUSGDG: This "+this.name+" needs a rigidbody2D to be able run away!");
		
		runFromThis = GameObject.Find("player");
		if (runFromThis == null)
			runFromThis = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D != null && runFromThis != null) {
			Vector2 direction = this.transform.position - runFromThis.transform.position;
			direction.Normalize();

			rigidbody2D.velocity = direction*speed;
		}
	}
}
