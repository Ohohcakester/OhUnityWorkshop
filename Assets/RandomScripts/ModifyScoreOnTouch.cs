using UnityEngine;

public class ModifyScoreOnTouch : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private string touchingObjectName = "Player";

    [SerializeField]
    private int scoreChange = -5;

    [SerializeField]
    private float cooldown = 0f;

    private float cooldownExpiryTime;

    // Called on start
    void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.ToLower() != touchingObjectName.ToLower()) return;

        if (gameManager != null)
        {
            if (Time.time >= cooldownExpiryTime)
            {
                gameManager.ModifyScore(scoreChange);
                cooldownExpiryTime = Time.time + cooldown;
            }
        }
    }

}