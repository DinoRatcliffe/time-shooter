using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float maxSpeed = 5F;
	public float moveForce = 365F;
	public float jumpForce = 1000F;

	private bool jump;	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		jump = Input.GetButtonDown ("Jump");
	}

	void FixedUpdate() {
		float hInput = Input.GetAxis ("Horizontal");

		if (hInput * GetComponent<Rigidbody> ().velocity.x < maxSpeed) {
			GetComponent<Rigidbody>().AddForce (Vector2.right * hInput * moveForce);
		}

		if (Mathf.Abs (GetComponent<Rigidbody> ().velocity.x) > maxSpeed) {
			GetComponent<Rigidbody> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody> ().velocity.x) * maxSpeed, GetComponent<Rigidbody>().velocity.y);
		}

		if (jump) {
			GetComponent<Rigidbody>().AddForce (new Vector2(0F, jumpForce));
			jump = false;
		}
	}
}
