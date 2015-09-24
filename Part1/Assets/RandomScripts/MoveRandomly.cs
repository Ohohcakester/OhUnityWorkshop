using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField]
    private float randomMoveIntervalMin = 0.5f;
    private float randomMoveIntervalMax = 1.1f;

    [SerializeField]
    private float minimumSpeed = 8f;
    [SerializeField]
    private float maximumSpeed = 14f;
    
    private float nextIntervalTime;

    private Rigidbody2D thisRigidbody2D;

    void Start()
    {
        thisRigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.time > nextIntervalTime)
        {
            nextIntervalTime += Random.Range(randomMoveIntervalMin, randomMoveIntervalMax);
            thisRigidbody2D.velocity = Random.insideUnitCircle * Random.Range(minimumSpeed, maximumSpeed);
        }
    }

}