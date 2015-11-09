using UnityEngine;
using System.Collections;

public class PhisicalObject : MonoBehaviour {
	public Vector3 gravity;
	public float drag = 0.1F;
	public float maxVelocity = 0.5F;
	public float timeScale = 1F;

	public Vector3 trajectory;
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
		//transform.position -= new Vector3 (0,  gravity, 0);
		AddForce ((trajectory * -1) * drag * timeScale);
		transform.position += gravity * timeScale;
		transform.position += trajectory * timeScale;
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
