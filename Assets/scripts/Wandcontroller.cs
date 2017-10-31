using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandcontroller : MonoBehaviour
{

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }

	private SteamVR_TrackedObject trackedObj;

	private GameObject pickup;

	public GameObject cameraRig;

	public GameObject upperLimitGO;
	public GameObject lowerLimitGO;

	float upperLimit;
	float lowerLimit;

	Vector3 gripPosition;
	Vector3 differencePosition;
	Vector3 cameraRigPosition;

	float gripY;
	float differenceY;



	Vector3 temp;

	bool isClimbing;

	// Use this for initialization
	void Start ()
	{
		upperLimit = upperLimitGO.transform.position.y + upperLimitGO.transform.lossyScale.y / 2;
		lowerLimit = lowerLimitGO.transform.position.y + lowerLimitGO.transform.lossyScale.y / 2-0.34f;

		trackedObj = GetComponentInParent<SteamVR_TrackedObject> ();
	}

	private void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "bar") {
			pickup = collider.gameObject;

		}


	}

	void OnTriggerStay (Collider other)
	{

	}

	private void OnTriggerExit (Collider collider)
	{
		//  if (collider.tag == "bar")
		//  pickup = null;
	}

	// Update is called once per frame
	void Update ()
	{
		solution1 ();

	}

	void solution2 ()
	{
		if (controller.GetPressDown (gripButton) && pickup != null) {
			Debug.Log ("Success");
			gripPosition = transform.position;
			cameraRigPosition = cameraRig.transform.position;
			isClimbing = true;
			Debug.Log (gripPosition);

		}
		if (controller.GetPressUp (gripButton)) {

			Debug.Log ("cameraRigPosition: " + cameraRigPosition);
			Debug.Log ("cameraRig Transform: " + cameraRig.transform.position);
			temp = cameraRigPosition;
			temp.y = cameraRig.transform.position.y;
			cameraRig.transform.position = temp;
			isClimbing = false;
			pickup = null;
			Debug.Log ("resetted cameraRig position");


		}

		if (isClimbing) {
			Debug.Log ("is climbing");

			differencePosition = (gripPosition - transform.position);

			cameraRig.transform.position += differencePosition;

			if (cameraRig.transform.position.y > upperLimit) {
				temp = cameraRig.transform.position;
				temp.y = upperLimit;
				cameraRig.transform.position = temp;
			}
			if (cameraRig.transform.position.y < lowerLimit) {
				temp = cameraRig.transform.position;
				temp.y = lowerLimit;
				cameraRig.transform.position = temp;
			}
		}
	}


	void solution1 ()
	{

		if (controller.GetPressDown (gripButton) && pickup != null) {
			Debug.Log ("Success");
			gripY = transform.position.y;
			isClimbing = true;
			Debug.Log (gripY);

		}
		if (controller.GetPressUp (gripButton)) {
			isClimbing = false;
			pickup = null;
		}

		if (isClimbing) {
			Debug.Log ("is climbing");

			differenceY = (gripY - transform.position.y);

			temp = cameraRig.transform.position;
			temp.y += differenceY;

			cameraRig.transform.position = temp;

			if (cameraRig.transform.position.y > upperLimit) {
				temp = cameraRig.transform.position;
				temp.y = upperLimit;
				cameraRig.transform.position = temp;
			}
			if (cameraRig.transform.position.y < lowerLimit) {
				temp = cameraRig.transform.position;
				temp.y = lowerLimit;
				cameraRig.transform.position = temp;
			}
		}
	}

}

