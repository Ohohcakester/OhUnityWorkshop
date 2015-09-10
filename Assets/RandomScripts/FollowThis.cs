using UnityEngine;

public class FollowThis : MonoBehaviour
{
    private GameObject followThis;

    [SerializeField]
    private string followThisName = "Player";

    [SerializeField]
    private float rate = 0.3f;


    // Use this for initialization
    void Start()
    {
        followThis = GameObject.Find(followThisName);
        if (followThis == null) followThis = GameObject.Find(followThisName.ToLower());
    }

    // Update is called once per frame
    void Update()
    {
        // Makes this object run away.
        if (followThis != null)
        {
            Vector3 displacement = followThis.transform.position - this.transform.position;
            displacement.z = 0;

            this.transform.position += displacement*rate;
        }
    }
}