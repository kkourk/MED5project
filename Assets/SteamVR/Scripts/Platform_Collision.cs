using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Collision : MonoBehaviour {

    bool onPlatform;
    public GameObject plain;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
            print("touched platdform");
        if (other.tag == "Player")
        {
            onPlatform = true;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlatform = false;
        }
    }

    void Update () {

        if (onPlatform == true)
            {

            plain.GetComponent<Plain_Move>().SetRotation();
            
        }
    


		
	}
}
