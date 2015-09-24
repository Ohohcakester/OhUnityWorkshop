using UnityEngine;

// Attach this script to make the object run away.

/** 
 * HOW IT WORKS:
 * This object will run away from the object stored in the variable "runFromThis".
 * Generally, "runFromThis" refers to the player. (initialised in Start())
 * 
 * [With smart = false]
 * On every frame, do
 *	1) Compute the vector from the position of runFromThis to this object's position.
 *      - i.e. this.transform.position - runFromThis.transform.position
 *  2) Normalise this vector, so we have a direction vector, multiply by speed.
 *  3) Move in this direction.
 *
 * If smart = true, it doesn't simply move in the opposite direction.
 * It also predicts if it will ram into a wall, and if it will, it moves in another direction.
 * It has slightly more complicated logic, which you can read in the code.
 */

public class RunAway : MonoBehaviour {

	private GameObject runFromThis;

    [SerializeField]
    private string runFromThisName = "Player";

	[SerializeField]
	private float speed = 4f;

	[SerializeField]
	private bool smart = false;


	// Use this for initialization
	void Start () {
		CheckForErrors();

		runFromThis = GameObject.Find(runFromThisName);
		if (runFromThis == null) runFromThis = GameObject.Find(runFromThisName.ToLower());
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



	// This function is not important.
	// I made it just to diagnose some possible errors that you might make during the workshop :D
	private void CheckForErrors() {
		if (GetComponent<Rigidbody2D>() == null)
			Debug.Log ("NUSGDG: This "+this.name+" needs a rigidbody2D to be able run away!");
	}
}
