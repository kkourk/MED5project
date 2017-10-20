﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Collision : MonoBehaviour {

    public GameObject plain;

    public int angle;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        print("touched platdform");
        if (other.tag == "lever")
        {
            Debug.Log(other.name);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            plain.GetComponent<Plain_Move>().SetRotation(angle);
        }

    }
}

