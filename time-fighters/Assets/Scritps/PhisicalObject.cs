using UnityEngine;
using System.Collections;

public class PhisicalObject : MonoBehaviour {
	public Vector3 gravity;
	public float drag = 0.1F;
	public float maxVelocity = 0.5F;
	public float timeScale = 1F;
	public bool collision = true;
	public bool noClip = false;

	public Vector3 trajectory;

	void Start () {

	}

	bool isAgainstLevel(Transform direction) {
		return Physics.Linecast (transform.position, direction.position, 1 << LayerMask.NameToLayer ("levelGeometry"));
	}

	void FixedUpdate () {
		RaycastHit hit = new RaycastHit ();
		if (Physics.Linecast (transform.position, transform.position + ((trajectory * -1) * drag * timeScale) + (gravity * timeScale) + (trajectory * timeScale), out hit)) {
			PhisicalObject obj = hit.collider.GetComponent<PhisicalObject>();
			if ((!obj || obj.collision) && !noClip) {
				trajectory =  trajectory - 2 * Vector3.Dot(trajectory, hit.normal) * (hit.normal);
				transform.position = hit.point;
				hit.collider.GetComponent<PhisicalObject>();
			} 
		}

		AddForce ((trajectory * -1) * drag * timeScale);
		transform.position += gravity * timeScale;
		transform.position += trajectory * timeScale;
	}

	public void AddForce(Vector3 force) {
		trajectory += force;
	}

	public void AddForce(Vector2 force) {
		AddForce(new Vector3 (force.x, force.y, 0));
	}
}
