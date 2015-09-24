using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_bullet;

    private float bulletSpeed = 20f;

	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Z))
	    {
	        var bullet = Instantiate(prefab_bullet, transform.position, prefab_bullet.transform.rotation) as GameObject;
	        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
	        bulletRigidbody.velocity = Vector3.up*bulletSpeed;
	    }
	}
}
