using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance {get; private set;}

	// Awake is called before start.
	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
