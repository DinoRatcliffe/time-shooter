using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float force = 1f;
	public int damage = 10;
	public GameObject shooter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void shoot(Vector2 direction, GameObject shooter) {
		this.shooter = shooter;
		PhisicalObject po = gameObject.GetComponent<PhisicalObject> ();
		po.AddForce (direction*force);
	}

	public void destroy(float time) {
		Destroy (gameObject, time);
	}

	public void damagedPlayer() {
		Destroy (gameObject);
	}
}
