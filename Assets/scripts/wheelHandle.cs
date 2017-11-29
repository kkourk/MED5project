using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelHandle : MonoBehaviour {

	Vector3 currentPos;

	public GameObject steeringWheel;

	Vector3 steeringWheelPos;
	float handleDistance;

	bool atLowerLimit;
	bool atUpperLimit;

	Vector3 handleDirection;

	SteamVR_Controller.Device controller;

	// Use this for initialization
	void Start()
	{
		steeringWheelPos = steeringWheel.transform.position;
		steeringWheelPos.y = transform.position.y;
		handleDistance = Vector3.Distance(transform.position, steeringWheelPos);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "GameController")
		{
			Debug.Log("Entered");
			controller = other.gameObject.GetComponent<Pickupobject>().controller;
		}
	}

	void OnTriggerStay(Collider other)
	{

		atLowerLimit = steeringWheel.GetComponent<wheelRotate>().atLowerLimit;
		atUpperLimit = steeringWheel.GetComponent<wheelRotate>().atUpperLimit;

		if (other.gameObject.GetComponent<Pickupobject>().controller == controller)
		{
			if (controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) 
			{
				
				if(atLowerLimit)
				{
					handleDirection = Vector3.forward;
				}
				else if (atUpperLimit)
				{
					handleDirection = Vector3.back;
				}
				else
				{
					currentPos = other.transform.position;
					currentPos.y = transform.position.y;
					transform.position = currentPos;
					handleDirection = Vector3.Normalize (transform.position - steeringWheelPos);
				}
				transform.position = steeringWheelPos + (handleDistance * handleDirection);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<Pickupobject>().controller == controller)
		{
			controller = null;
		}
	}
}