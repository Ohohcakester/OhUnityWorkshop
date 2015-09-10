using UnityEngine;

public class ChaseThis : MonoBehaviour {

    private GameObject chaseThis;

    [SerializeField]
    private string chaseThisName = "Player";

    [SerializeField]
    private float speed = 4f;


    // Use this for initialization
    void Start()
    {
        chaseThis = GameObject.Find(chaseThisName);
        if (chaseThis == null) chaseThis = GameObject.Find(chaseThisName.ToLower());
    }

    // Update is called once per frame
    void Update()
    {
        // Makes this object run away.
        if (GetComponent<Rigidbody2D>() != null && chaseThis != null)
        {
            Vector2 direction = this.transform.position - chaseThis.transform.position;

            direction.Normalize();

            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
    }
}
