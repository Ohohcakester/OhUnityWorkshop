using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{

    public bool isEnemyBullet;

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

        var hitPoints = collider.GetComponent<HitPoints>();
        if (hitPoints != null)
        {
            Destroy(gameObject);
            hitPoints.TakeDamage(1);
        }
    }
}
