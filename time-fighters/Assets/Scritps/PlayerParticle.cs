﻿using UnityEngine;
using System.Collections;

public class PlayerParticle : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public Vector3 finalPosition;
	public Quaternion finalRotation;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Rigidbody> ().detectCollisions = false;
		GetComponent<BoxCollider> ().enabled = false;

		originPosition = transform.localPosition;
		originRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void scatter() {
		GetComponent<BoxCollider> ().enabled = true;
		GetComponent<PhisicalObject> ().AddForce (new Vector3(Random.Range (-1F, 1F)*2, Random.Range (-1F, 1F)*2, Random.Range (-1F, 0)*2));
	}	

	public void startReform() {
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Rigidbody> ().detectCollisions = false;
		GetComponent<BoxCollider> ().enabled = false;

		finalPosition = transform.localPosition;
		finalRotation = transform.rotation;
	}

	public void ReformLerp(float lerp) {
		transform.localPosition = Vector3.Lerp (finalPosition, originPosition, lerp);
		transform.rotation = Quaternion.Lerp (finalRotation, originRotation, lerp);
	}
}
