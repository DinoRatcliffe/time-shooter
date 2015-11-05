using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float maxSpeed = 5F;
	public float moveForce = 365F;
	public float jumpForce = 300F;
	Transform groundAnchor;
	private bool jump;	
	private int airJumps = 0;
	public int airJumpsAllowed = 1;
	// Use this for initialization
	void Start () {
		groundAnchor = transform.Find ("ground");
	}

	bool isOnGround() {
		return Physics.Linecast (transform.position, groundAnchor.position, 1 << LayerMask.NameToLayer("floor")); //todo: mask to certain layers if necessary
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

		if (hInput * GetComponent<Rigidbody> ().velocity.x < maxSpeed) {
			GetComponent<Rigidbody>().AddForce (Vector2.right * hInput * moveForce);
		}

		if (Mathf.Abs (GetComponent<Rigidbody> ().velocity.x) > maxSpeed) {
			GetComponent<Rigidbody> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody> ().velocity.x) * maxSpeed, GetComponent<Rigidbody>().velocity.y);
		}

		if (jump) { 
			if (isOnGround()) {
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
