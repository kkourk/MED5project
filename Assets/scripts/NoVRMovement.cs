using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVRMovement : MonoBehaviour
{

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    float moveX;
    float moveZ;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.MovePosition(transform.position + new Vector3(moveX, 0, moveZ));

        if (transform.parent)
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("space key was pressed");
                transform.parent.GetComponent<platformMovement>().MovePlatform();
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "MovingPlatform")
        {
            Debug.Log(other.name);
            transform.parent = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            transform.parent = null;
        }

    }

}
