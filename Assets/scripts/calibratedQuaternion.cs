using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calibratedQuaternion : MonoBehaviour {

	public GameObject currentTracker, trackerWhenCalibrating, calibrationPose;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = currentTracker.transform.rotation * Quaternion.Inverse(trackerWhenCalibrating.transform.rotation) * calibrationPose.transform.rotation;
	}
}
