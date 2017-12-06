using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Rigidbody rigidbody;

	private bool currentlyInteracting;

	private float velocityFactor = 20000f;
	private Vector3 posDelta;

	private float rotationFactor = 600f;
	private Quaternion rotationDelta;
	private float angle;
	private Vector3 axis;

	private Pickupobject attachedPickup;

	private Transform interactionPoint;

	public AudioClip wallHit;
	public AudioClip boxHit;
	public AudioClip grab;

	AudioSource audio;


	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
		interactionPoint = new GameObject ().transform;
		velocityFactor /= 5;
		rotationFactor /= 5;

		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (attachedPickup && currentlyInteracting) {
			posDelta = attachedPickup.transform.position - interactionPoint.position;
			this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

			rotationDelta = attachedPickup.transform.rotation * Quaternion.Inverse (interactionPoint.rotation);
			rotationDelta.ToAngleAxis (out angle, out axis);

			if (angle > 180) {
				angle -= 360;
			}

			this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
		}
	}

	public void BeginInteraction (Pickupobject wand)
	{
		attachedPickup = wand;
		interactionPoint.position = wand.transform.position;
		interactionPoint.rotation = wand.transform.rotation;
		interactionPoint.SetParent (transform, true);
		currentlyInteracting = true;

		audio.clip = grab;
		audio.Play();

	}

	public void EndInteraction (Pickupobject wand)
	{
		if (wand == attachedPickup) {
			attachedPickup = null;
			currentlyInteracting = false;
		}
	}

	public bool IsInteracting ()
	{
		return currentlyInteracting;
	}

    private void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Box") {
			audio.clip = boxHit;
			audio.Play();
		}
		if (collider.tag == "Wall") {
			audio.clip = wallHit;
			audio.Play();
		}
	}
}
