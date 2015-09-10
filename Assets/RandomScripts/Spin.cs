using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float spinRate;

    private Rigidbody2D thisRigidbody2D;

    private void Start()
    {
        thisRigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (thisRigidbody2D != null)
        {
            thisRigidbody2D.angularVelocity = spinRate*50;
        }
        else
        {
            this.transform.eulerAngles += new Vector3(0, 0, spinRate);
        }
    }

}
