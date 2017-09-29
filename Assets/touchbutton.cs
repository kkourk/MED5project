using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchbutton : MonoBehaviour {

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
        if (other.gameObject.tag == "button")
        {
            Debug.Log("debug");
            GetComponentInParent<platformMovement>().MovePlatform();
        }
    }
}
