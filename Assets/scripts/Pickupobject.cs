using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupobject : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    //HashSet<InteractableItem>();

    private GameObject pickup;

    Vector3 gripPosition;

    // Use this for initialization
    void Start () {

        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "shape") {
            pickup = collider.gameObject;
        }

    }

    private void OnTriggerExit(Collider collider){
        if (collider.tag == "shape")
            pickup = null;
    }

    // Update is called once per frame
    void Update () {

        if (controller == null){
            Debug.Log("controller not found");
            return;
        }

        if (controller.GetPressDown(gripButton) && pickup != null){
            Debug.Log("Success");
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().useGravity = false;

        }
        if (controller.GetPressUp(gripButton) && pickup != null){
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().useGravity = true;
        }
       
    }

}

