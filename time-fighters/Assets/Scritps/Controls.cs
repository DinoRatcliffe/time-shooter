using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float maxSpeed = 5F;
	public float moveForce = 365F;
	public float jumpForce = 300F;
	public float airMovementFactor = 1F;
	public float wallSlideFactor = 0.02F;
	public bool wallJumpAllowed = true;
	public bool wallResetsJumps = true;
	public int airJumpsAllowed = 1;
	
	private Transform downAnchor, rightAnchor, leftAnchor;
	private bool jump;	
	private int airJumps = 0;
	public int playerNum = 1;
	private bool altDown;
	// Use this for initialization
	void Start () {
		downAnchor = transform.Find ("down");
		leftAnchor = transform.Find ("left");
		rightAnchor = transform.Find ("right");
	}

	bool isAgainstLevel(Transform direction) {
		return Physics.Linecast (transform.position, direction.position, 1 << LayerMask.NameToLayer ("levelGeometry"));
	}

	// Update is called once per frame
	void Update () {
		jump = jump || Input.GetButtonDown ("JUMP_P" + playerNum);
		if (Input.GetButtonDown ("FIRE_P" + playerNum)) {
			gameObject.GetComponent<Crosshair>().Fire();
		}

		if (Input.GetButtonDown ("FIRE_ALT_P" + playerNum) && !altDown) {
			gameObject.GetComponent<Crosshair> ().AltFire ();
			altDown = true;
		} else if (Input.GetButtonUp ("FIRE_ALT_P" + playerNum) && altDown) {
			gameObject.GetComponent<Crosshair> ().AltFireDeploy();
			altDown = false;
		}

		if (Input.GetButtonDown ("CLEAR_ALT_P" + playerNum)) {
			gameObject.GetComponent<Crosshair> ().AltFireClear();
			altDown = false;
		}
	}

	void addJumpForce() {
		GetComponent<PhisicalObject>().AddForce (new Vector2(0F, jumpForce));
	}

	void wallJump() {
		if (isAgainstLevel (rightAnchor)) {
			GetComponent<PhisicalObject>().AddForce (new Vector2(-jumpForce, jumpForce));
		} else if (isAgainstLevel (leftAnchor)) {
			GetComponent<PhisicalObject>().AddForce (new Vector2(jumpForce, jumpForce));
		}
	}

	public void setPlayerNum(int i) {
		playerNum = i;
	}

	void FixedUpdate() {
		float hInput = Input.GetAxis ("MoveHorizontal_P" + playerNum);

		// update croshair
		gameObject.GetComponent<Crosshair> ().updateAimLocation (
			new Vector2(
			Input.GetAxis ("AimHorizontal_P" + playerNum), 
			Input.GetAxis ("AimVertical_P" + playerNum)));

		// limit air movement
		if (!isAgainstLevel (downAnchor)) {
			hInput *= airMovementFactor;
		}

		// left right movement
		if (Mathf.Abs(GetComponent<PhisicalObject> ().trajectory.x) < maxSpeed) {
			GetComponent<PhisicalObject>().AddForce (Vector2.right * hInput * moveForce);
		}

		// limit jumping to number of air jumps 
		if (jump) { 
			bool isAgainstWall = isAgainstLevel(rightAnchor) || isAgainstLevel(leftAnchor);

			if (isAgainstLevel(downAnchor)) {
				addJumpForce();
				airJumps = 0;
			} else if (wallJumpAllowed && isAgainstWall) {
				wallJump ();
				if (wallResetsJumps) airJumps = 0;
			}else if(airJumps < airJumpsAllowed) {
				addJumpForce();
				airJumps++;
			}
			jump = false;
		}
	}
}
