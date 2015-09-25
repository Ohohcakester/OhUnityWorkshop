using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

    [SerializeField]
    private int maxHp = 1;

    private int hp;

	// Use this for initialization
	void Start () {
        hp = maxHp;
	}


    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
