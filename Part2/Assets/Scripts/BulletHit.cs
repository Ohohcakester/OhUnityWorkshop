using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{

    public bool isEnemyBullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isEnemyBullet)
        {
            if (collider.tag != "Player") return;
        }
        else
        {
            if (collider.tag != "Enemy") return;
        }

        Destroy(gameObject);
        Destroy(collider.gameObject);
    }
}
