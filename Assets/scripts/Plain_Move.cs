using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plain_Move : MonoBehaviour {

    public float rotationSpeed;
    float rotation = 0;
    public float maxRotation = 0;
    

    bool isRotating = false;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {


        //transform.eulerAngles = new Vector3(0, maxRotation, 0);

        if (rotation < maxRotation)
        {
            isRotating = true;
            rotation += rotationSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rotation, 0);

            if (rotation > maxRotation)
            {
                isRotating = false;
                rotation = maxRotation;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }

        }
        if (rotation > maxRotation)
        {
            isRotating = true;
            rotation -= rotationSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rotation, 0);

            if (rotation < maxRotation)
            {
                isRotating = false;
                rotation = maxRotation;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }

        }

    }

    public void SetRotation()
    { if (!isRotating)
        {
            if (maxRotation == 90)
            {
                maxRotation = 0;
            }
            else
            {
                maxRotation = 90;
            }
            

        }

    }

}

