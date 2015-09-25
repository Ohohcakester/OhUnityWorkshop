using UnityEngine;
using System.Collections;

public class Expiry : MonoBehaviour
{
    [SerializeField]
    private float expireDuration = 10f;

    private float expireTime;

	// Use this for initialization
	void Start ()
	{
	    expireTime = Time.time + expireDuration;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Time.time > expireTime)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
