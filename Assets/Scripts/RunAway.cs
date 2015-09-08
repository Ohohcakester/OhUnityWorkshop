using UnityEngine;
using System.Collections;

// Attach this script to make the object run away.

public class RunAway : MonoBehaviour {

	private GameObject runFromThis;

	[SerializeField]
	private float speed = 4f;

	[SerializeField]
	private bool smart = false;


	// Use this for initialization
	void Start () {
		CheckForErrors();

		runFromThis = GameObject.Find("player");
		if (runFromThis == null)
			runFromThis = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Makes this object run away.
		if (GetComponent<Rigidbody2D>() != null && runFromThis != null) {
			Vector2 direction = this.transform.position - runFromThis.transform.position;

			if (smart)
				direction = SmartDirection(direction);

			direction.Normalize();

			GetComponent<Rigidbody2D>().velocity = direction*speed;
		}
	}


	private void CheckForErrors() {
		if (GetComponent<Rigidbody2D>() == null)
			Debug.Log ("NUSGDG: This "+this.name+" needs a rigidbody2D to be able run away!");
	}


	// For fun. This makes the running away a little smarter. (Avoids walls)
	private Vector2 SmartDirection(Vector2 direction) {
		bool hitSomething = false;

		var hits = Physics2D.RaycastAll(this.transform.position, direction, 2);
		foreach (var hit in hits) {
			if (hit.collider.gameObject != this.gameObject) {
				hitSomething = true;
			}
		}

		if (!hitSomething)
			return direction;
		hitSomething = false;
		
		hits = Physics2D.RaycastAll(this.transform.position, RotateLeft(direction), 2);
		foreach (var hit in hits) {
			if (hit.collider.gameObject != this.gameObject) {
				hitSomething = true;
			}
		}
		
		if (!hitSomething)
			return direction + RotateLeft(direction).normalized*5f;
		hitSomething = false;
		
		hits = Physics2D.RaycastAll(this.transform.position, RotateRight(direction), 2);
		foreach (var hit in hits) {
			if (hit.collider.gameObject != this.gameObject) {
				hitSomething = true;
			}
		}
		
		if (!hitSomething)
			return direction + RotateRight(direction).normalized*5f;



		return direction;
	}

	private Vector2 RotateLeft(Vector2 direction) {
		return new Vector2(-direction.y, direction.x);
	}

	private Vector2 RotateRight(Vector2 direction) {
		return new Vector2(direction.y, -direction.x);
	}

}
