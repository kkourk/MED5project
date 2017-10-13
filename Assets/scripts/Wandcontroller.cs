using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandcontroller : MonoBehaviour
{

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject pickup;

    public GameObject cameraRig;

    Vector3 gripPosition;
    Vector3 difference;
    bool isClimbing;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "bar")
        {
            pickup = collider.gameObject;

        }


    }

    private void OnTriggerExit(Collider collider)
    {
      //  if (collider.tag == "bar")
          //  pickup = null;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (controller == null)
        {
            Debug.Log("controller not found");
            return;
        }

        if (controller.GetPressDown(gripButton) && pickup != null)
        {
            Debug.Log("Success");
            gripPosition = transform.position;
            isClimbing = true;
            Debug.Log(gripPosition);

        }
        if (controller.GetPressUp(gripButton))
        {
            isClimbing = false;
			pickup = null;
        }

        if (isClimbing)
        {
            Debug.Log("is climbing");
            difference = (gripPosition - transform.position);

            cameraRig.transform.position += difference;
        }
    }


}
