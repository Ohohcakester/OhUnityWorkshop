using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    private float speedIncrement = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.GetComponent<Controller>();
        if (controller == null) return;

        controller.IncreaseSpeed(speedIncrement);
        Destroy(this.gameObject);
    }
}
