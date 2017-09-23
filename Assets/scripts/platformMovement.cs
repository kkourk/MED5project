using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

    public GameObject start, middle, end;
    public float t =0.0f, velocitySpeed = 0.2f;

    float velocity =0;
    // Use this for initialization
	void Start () {

        
}
	
	// Update is called once per frame
	void Update () {
    t += velocity * Time.deltaTime;
    if (t > 1.0) { t = 1.0f; }
    if (t < 0.0) { t = 0.0f; }
    transform.position =
            Mathf.Pow(1 - t, 2) * start.transform.position
            + 2 * (1 - t) * t * middle.transform.position
            + Mathf.Pow(t, 2) * end.transform.position;
    }

    public void MovePlatform()
    {
        if (transform.position == start.transform.position)
        {
            velocity = 0.2f;
        }
        else if (transform.position == end.transform.position)
        {
            velocity = -0.2f;
        }
    }
}
