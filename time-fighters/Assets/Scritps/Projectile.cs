using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float force = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void shoot(Vector2 direction) {
		PhisicalObject po = gameObject.GetComponent<PhisicalObject> ();
		Debug.Log (direction);
		po.AddForce (direction*force);
	}

	public void destroy(float time) {
		Destroy (gameObject, time);
	}
}
