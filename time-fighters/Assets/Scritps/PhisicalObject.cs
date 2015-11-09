using UnityEngine;
using System.Collections;

public class PhisicalObject : MonoBehaviour {
	public float gravity = 0.1F;
	public float drag = 0.1F;
	public float maxVelocity = 0.5F;

	public Vector3 trajectory;
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
		//transform.position -= new Vector3 (0,  gravity, 0);
		AddForce ((trajectory * -1) * drag);
		transform.position += new Vector3 (0, gravity * -1, 0);
		transform.position += trajectory;
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("enter");
	}
	
	public void AddForce(Vector3 force) {
		trajectory += force;
	}

	public void AddForce(Vector2 force) {
		AddForce(new Vector3 (force.x, force.y, 0));
	}
}
