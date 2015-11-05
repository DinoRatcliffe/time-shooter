using UnityEngine;
using System.Collections;

public class StateCapture : MonoBehaviour {
	
	Vector3 angularVelocity;
	Vector3 velocity;
	
	bool captured = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void CaptureState() {
		Rigidbody rb = GetComponent<Rigidbody> ();
		velocity = rb.velocity;
		angularVelocity = rb.angularVelocity;
		captured = true;
	}
	
	void RevertState() {
		if (captured) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.velocity = this.velocity;
			rb.angularVelocity = this.angularVelocity;
			captured = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
