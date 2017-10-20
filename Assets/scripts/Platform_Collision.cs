using System.Collections;
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
        if (other.tag == "lever") ;
    }

}

