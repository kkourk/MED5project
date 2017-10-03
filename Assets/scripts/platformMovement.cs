using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{

    public GameObject[] platform;

    public GameObject middle;


    public float t = 0.0f, velocitySpeed = 0.2f;

    float velocity = 0;
    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        t += velocity * Time.deltaTime;
        if (t > 1.0)
        {
            changePlatforms();
            t = 0.0f;
            velocity = 0;

        }
        else
        {
            transform.position =
                Mathf.Pow(1 - t, 2) * platform[0].transform.position
                + 2 * (1 - t) * t * middle.transform.position
                + Mathf.Pow(t, 2) * platform[1].transform.position;
        }

        if (t < 0.0) { t = 0.0f; }

    }

    void changePlatforms()
    {
        GameObject temp = platform[0];

        for (int i = 0; i < platform.Length; i++)
        {
            if (i == platform.Length - 1)
            {

                platform[i] = temp;
            }
            else
            {
                platform[i] = platform[i + 1];

            }
            middle.transform.position = platform[1].transform.position + new Vector3(0, 2, 0);

        }


    }

    public void MovePlatform()
    {
        if (transform.position == platform[0].transform.position)
        {
            t = 0;
            velocity = velocitySpeed;
        }
    }
}
