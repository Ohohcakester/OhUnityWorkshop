﻿using UnityEngine;
using System.Collections;

// This code is for making the player move!
// If you attach this code to something, it will respond to your arrow keys and move.
// But it needs a rigidbody to work. So remember to attach one to the gameobject.

/** 
 * HOW IT WORKS:
 * 
 * This script makes it so that on every frame:
 *   1) Check if any of the Up/Down/Left/Right keys are being held down.
 *   2) If it is, set the velocity of this object to be in the direction of the keys held down.
 */

public class Controller : MonoBehaviour {

	// Use [SerializeField] or public to make the variable editable from the unity interface.
	[SerializeField]
	private float speed = 15f;

	
	// Update is called once every frame.
	void Update () {

		// Movement controls.
		if (GetComponent<Rigidbody2D>() != null) {
			Vector2 velocity = Vector2.zero; // a Vector2 has an x and y coordinate.
			
			if (Input.GetKey(KeyCode.UpArrow))
				velocity += Vector2.up*speed; // Vector2.up is defined as (0,1)
			
			if (Input.GetKey(KeyCode.DownArrow))
				velocity -= Vector2.up*speed;
			
			if (Input.GetKey(KeyCode.LeftArrow))
				velocity -= Vector2.right*speed; // Vector2.right is defined as (1,0)
			
			if (Input.GetKey(KeyCode.RightArrow))
				velocity += Vector2.right*speed;

			GetComponent<Rigidbody2D>().velocity  = velocity; // Update the rigidbody's velocity.
		}

	}

	// Called at the start of the game.
	void Start() {
		CheckForErrors();
	}


	// This function is not important.
	// I made it just to diagnose some possible errors that you might make during the workshop :D
	void CheckForErrors(){
		if (GetComponent<Rigidbody2D>() == null)
			Debug.Log ("NUSGDG: Hey, you haven't attached the Rigidbody2D to the player!");
	}
}
