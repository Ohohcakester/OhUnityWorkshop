using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class ShootingAdvanced : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_bullet;

    [SerializeField]
    private float cooldown = 0.1f;
    
    [SerializeField]
    private float bulletSpeed = 20f;

    private float nextShootTime = float.NegativeInfinity;
    private Vector3 gunOffsetLeft = new Vector3(-0.25f, 0.6f, 0);
    private Vector3 gunOffsetRight = new Vector3(0.25f, 0.6f, 0);

	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKey(KeyCode.Z))
	    {
	        if (Time.time >= nextShootTime)
	        {
	            nextShootTime = Time.time + cooldown;

                ShootBullet(transform.position + gunOffsetLeft);
                ShootBullet(transform.position + gunOffsetRight);
	        }
	    }
	}

    private void ShootBullet(Vector3 spawnLocation)
    {
        var bullet = Instantiate(prefab_bullet, spawnLocation, prefab_bullet.transform.rotation) as GameObject;
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector3.up * bulletSpeed;
    }
}
