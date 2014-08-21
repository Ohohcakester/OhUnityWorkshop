using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	private GameManager gameManager;

	// Called on start
	void Start() {
		if (collider2D == null) {
			Debug.Log ("NUSGDG: Attach a collider to your collectible!");
		}
		/*else if (collider2D.isTrigger == false) {
			Debug.Log ("NUSGDG: Set isTrigger (in the Box Collider 2D settings) to true for the pickup to work");
		}*/

		gameManager = GameManager.instance;
		if (gameManager != null)
			gameManager.IncrementCollectibleCount();

	}

	// Called when some other object enters your hitbox. (note: isTrigger must be on!
	void OnCollisionEnter2D(Collision2D collision) {
		var other = collision.collider;
		// First we need to check whether the thing it's colliding with is the player.

		// Method 1: Check object name
		if (other.name.ToLower() != "player") return;

		// Method 2: Check object tag
		//if (other.tag != 7) return;

		// Method 3: Check whether object has the script component "Controller" attached.
		//var controller = other.GetComponent<Controller>();
		//if(controller == null) return;

		if (gameManager != null) {
			gameManager.ItemCollected();
		}
		Destroy(this.gameObject);
	}
}
