﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupobject : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	HashSet<Interactable> objectsHoveringOver = new HashSet<Interactable>();

	private Interactable closestItem;
	private Interactable interactingItem;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log("Controller not initialized");
			return;
		}

		if (controller.GetPressDown(triggerButton)) {
			float minDistance = float.MaxValue;

			float distance;
			foreach (Interactable item in objectsHoveringOver) {
				distance = (item.transform.position - transform.position).sqrMagnitude;

				if (distance < minDistance) {
					minDistance = distance;
					closestItem = item;
				}
			}

			interactingItem = closestItem;

			if (interactingItem) {
				if (interactingItem.IsInteracting()) {
					interactingItem.EndInteraction(this);
				}

				interactingItem.BeginInteraction(this);
			}
		}

		if (controller.GetPressUp(triggerButton) && interactingItem != null) {
			interactingItem.EndInteraction(this);
		}
	}

	private void OnTriggerEnter(Collider collider) {
		Interactable collidedItem = collider.GetComponent<Interactable>();
		if (collidedItem) {
			objectsHoveringOver.Add(collidedItem);
		}
	}

	private void OnTriggerExit(Collider collider) {
		Interactable collidedItem = collider.GetComponent<Interactable>();
		if (collidedItem) {
			objectsHoveringOver.Remove(collidedItem);
		}
	}
}