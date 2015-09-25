using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float spawnInterval = 4f;

    [SerializeField]
    private GameObject prefab_enemy;

    private float nextSpawnTime;

	// Use this for initialization
	void Start ()
	{
	    nextSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > nextSpawnTime)
	    {
	        SpawnEnemy();
	        nextSpawnTime = Time.time + spawnInterval;
	    }
	}

    private void SpawnEnemy()
    {
        float x = Random.Range(-5f, 5f);
        float y = 8.5f;

        var enemy = Instantiate(prefab_enemy, new Vector3(x, y, 0), prefab_enemy.transform.rotation);
    }
}
