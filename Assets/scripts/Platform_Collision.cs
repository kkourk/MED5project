using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Collision : MonoBehaviour {

    public GameObject plain;

<<<<<<< HEAD
    public int angle;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        print("touched platdform");
        if (other.tag == "lever")
=======

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
            print("touched platform");
        if (other.tag == "Player")
>>>>>>> d6ca6f7e9966d447f394110b163d0261d9427d1a
        {
            Debug.Log(other.name);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            plain.GetComponent<Plain_Move>().SetRotation(angle);
        }

    }
}

