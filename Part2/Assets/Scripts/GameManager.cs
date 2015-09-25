using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float spawnInterval = 3f;

    [SerializeField]
    private GameObject prefab_enemy;

    private float nextSpawnTime;

    public static GameManager instance { get; private set; }
    private int score;

    private void Awake()
    {
        instance = this;
    }

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
	        spawnInterval *= 0.99f;
	    }
	}

    private void SpawnEnemy()
    {
        float x = Random.Range(-8f, 8f);
        float y = 8.5f;

        var pattern = GetRandomPattern();
        var enemy = Instantiate(prefab_enemy, new Vector3(x, y, 0), prefab_enemy.transform.rotation) as GameObject;
        enemy.GetComponent<EnemyShooting>().SetBulletPattern(pattern);
    }

    private EnemyShooting.BulletPattern GetRandomPattern()
    {
        int choice = Random.seed%6;
        switch (choice)
        {
            case 0: return EnemyShooting.BulletPattern.RANDOM_SPRAY;
            case 1: return EnemyShooting.BulletPattern.BURST;
            case 2: return EnemyShooting.BulletPattern.WAVES;
            case 3: return EnemyShooting.BulletPattern.SPIRAL;
            case 4: return EnemyShooting.BulletPattern.LOOPS;
            case 5: return EnemyShooting.BulletPattern.RINGS;
        }
        return EnemyShooting.BulletPattern.RANDOM_SPRAY;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    void OnGUI()
    {
        var rect = new Rect(0, 0, 50, 50);
        GUI.Label(rect, "Score: " + score);
    }
}
