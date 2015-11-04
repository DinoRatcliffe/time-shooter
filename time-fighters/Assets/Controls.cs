using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float maxSpeed = 5F;
	public float moveForce = 365F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float hInput = Input.GetAxis ("Horizontal");

		if (hInput * GetComponent<Rigidbody> ().velocity.x < maxSpeed) {
			GetComponent<Rigidbody>().AddForce (Vector2.right * hInput * moveForce);
		}
	}
}
