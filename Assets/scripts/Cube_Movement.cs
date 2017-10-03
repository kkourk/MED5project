using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Movement : MonoBehaviour {


    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float thrust;
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * thrust);
        }

        
    }
}
