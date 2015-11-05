using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float maxSpeed = 5F;
	public float moveForce = 365F;
	public float jumpForce = 300F;
	Transform downAnchor, rightAnchor, leftAnchor;
	private bool jump;	
	private int airJumps = 0;
	public int airJumpsAllowed = 1;
	// Use this for initialization
	void Start () {
		downAnchor = transform.Find ("down");
		rightAnchor = transform.Find ("right");
		leftAnchor = transform.Find ("left");
	}

	bool isAgainstLevel(Transform direction) {
		return Physics.Linecast (transform.position, direction.position, 1 << LayerMask.NameToLayer ("levelGeometry"));
	}

	// Update is called once per frame
	void Update () {
		jump = Input.GetButtonUp ("Jump");
	}

	void addJumpForce() {
		GetComponent<Rigidbody>().AddForce (new Vector2(0F, jumpForce));
	}

	void FixedUpdate() {
		float hInput = Input.GetAxis ("Horizontal");

		// prevent wall hang 
		if (hInput > 0 && isAgainstLevel (rightAnchor) ||
		    hInput < 0 && isAgainstLevel (leftAnchor)) {
			hInput *= 0F;
		}

		// left right movement
		if (hInput * GetComponent<Rigidbody> ().velocity.x < maxSpeed) {
			GetComponent<Rigidbody>().AddForce (Vector2.right * hInput * moveForce);
		}

		// clamp to max speed
		if (Mathf.Abs (GetComponent<Rigidbody> ().velocity.x) > maxSpeed) {
			GetComponent<Rigidbody> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody> ().velocity.x) * maxSpeed, GetComponent<Rigidbody>().velocity.y);
		}

		// limit jumping to number of air jumps 
		if (jump) { 
			if (isAgainstLevel(downAnchor)) {
				addJumpForce();
				airJumps = 0;
			} else if(airJumps < airJumpsAllowed) {
				addJumpForce();
				airJumps++;
			}
			jump = false;
		}
	}
}
