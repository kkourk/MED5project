using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotate : MonoBehaviour {

	//set gripPosition when they press button
	//only track controller when button is down
	//set controller gameobject to null when button is not pressed

	public GameObject plane;
	public int turnsPerLoop;

	public int lowerLimit;
	public int upperLimit;

	Vector3 currentPos;

	float prevAngle;
	float angle;

	public bool atUpperLimit;
	public bool atLowerLimit;

public float soundTolerance;

    GameObject handle;

public AudioSource rattling;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "handle")
		{
			currentPos = handle.transform.position;
			currentPos.y = transform.position.y;
			transform.LookAt(currentPos);

			if (prevAngle - transform.eulerAngles.y > 180)
			{
				angle += 360;
			}
			if (prevAngle - transform.eulerAngles.y < -180)
			{
				angle -= 360;
			}

			rattling.volume =  Mathf.Abs(prevAngle - transform.eulerAngles.y)/10;

			plane.transform.eulerAngles = new Vector3(0,(transform.eulerAngles.y + angle)/turnsPerLoop,0);
			prevAngle = transform.eulerAngles.y;

			if (plane.transform.eulerAngles.y+angle <lowerLimit)
			{
				plane.transform.eulerAngles = setRotation(lowerLimit);
				transform.eulerAngles = setRotation (lowerLimit * turnsPerLoop);
				atLowerLimit = true;
			}
			else if (plane.transform.eulerAngles.y >upperLimit)
			{
				plane.transform.eulerAngles = setRotation(upperLimit);
				transform.eulerAngles = setRotation (upperLimit * turnsPerLoop);
				atUpperLimit = true;
			}
			else
			{
			atLowerLimit = false;
			atUpperLimit = false;
			}

		}
	}
	Vector3 setRotation(int angle)
	{
		return new Vector3(0, angle, 0);
	}

}
