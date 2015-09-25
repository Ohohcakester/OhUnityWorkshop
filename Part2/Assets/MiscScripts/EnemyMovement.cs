using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 1f;
    [SerializeField]
    private float sidewaysMovementSpeed = 0.5f;
    [SerializeField]
    private float transitionTimeMin = 1f;
    [SerializeField]
    private float transitionTimeMax = 2f;

    private Vector3 velocityLeft;
    private Vector3 velocityCenter;
    private Vector3 velocityRight;

    private float nextTransitionTime;

    private static System.Random rand = new System.Random();
    private Rigidbody2D rigidbody2D;

	// Use this for initialization
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityLeft = new Vector3(-sidewaysMovementSpeed, -movementSpeed, 0);
        velocityCenter = new Vector3(0, -movementSpeed, 0);
        velocityRight = new Vector3(sidewaysMovementSpeed, -movementSpeed, 0);
        nextTransitionTime = float.NegativeInfinity;
    }

	// Update is called once per frame
	void Update () {
	    if (Time.time > nextTransitionTime)
	    {
	        int choice = rand.Next(0, 3);
	        switch (choice)
            {
                case 0:
                    rigidbody2D.velocity = velocityLeft;
                    break;
                case 1:
                    rigidbody2D.velocity = velocityCenter;
                    break;
                case 2:
                    rigidbody2D.velocity = velocityRight;
                    break;
            }

            nextTransitionTime = Time.time + Random.Range(transitionTimeMin, transitionTimeMax);
	    }
	}
}
