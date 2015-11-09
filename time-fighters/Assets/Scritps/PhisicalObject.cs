using UnityEngine;
using System.Collections;

public class PhisicalObject : MonoBehaviour {
	public float gravity = 0.1F;
	public float drag = 0.01F;
	public float maxVelocity = 0.5F;

	public Vector3 trajectory;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position -= new Vector3 (0,  gravity, 0);
		AddForce(new Vector3(0, gravity*-1, 0));
		transform.position += trajectory;
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("enter");
	}

	public Vector3 ClampVelocity(Vector3 trajectory) {
		Debug.Log (trajectory.magnitude);
		if (trajectory.magnitude > maxVelocity) {
			trajectory = trajectory.normalized;
			trajectory.Scale (new Vector3 (maxVelocity, maxVelocity, maxVelocity));
		}
		return trajectory;
	}

	public void AddForce(Vector3 force) {
		trajectory += force;
		trajectory = ClampVelocity (trajectory);
	}

	public void AddForce(Vector2 force) {
		AddForce(new Vector3 (force.x, force.y, 0));
	}
}
