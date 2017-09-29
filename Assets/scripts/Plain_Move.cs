using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plain_Move : MonoBehaviour {
    

    public float rotationSpeed = 100.0F;
    float rotation = 0;
    float maxRotation = 0;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (transform.eulerAngles.y < maxRotation) {

            print("Rotating... " + transform.eulerAngles.y);
            rotation = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);

        }

    }

    public void SetRotation()
    {
        if (maxRotation < 360)
            maxRotation += 90;
        else
            maxRotation = 0;
        print(maxRotation);
    }
}
