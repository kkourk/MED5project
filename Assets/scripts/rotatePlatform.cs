using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlatform : MonoBehaviour {

    public GameObject plane;
    
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.tag == "button")
        {
           // plane.GetComponent<Plain_Move>().SetRotation();
        }
    }
}

