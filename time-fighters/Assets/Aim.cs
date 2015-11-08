using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	Vector3 mousePosition;
	Vector3 objectPosition;
	GameObject projectile;
	Transform muzzle;

	// Use this for initialization
	void Start () {
		muzzle = transform.FindChild ("muzzle");
		projectile = Resources.Load ("aimtest/Projectile") as GameObject;
	}

	void Fire() {

		Instantiate (projectile, muzzle.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		objectPosition = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 result;
		result = mousePosition - objectPosition;
		float angle = Mathf.Atan2 (result.y, result.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, angle);
		if (Input.GetMouseButtonDown (0)) {
			Fire ();
		}
	}
}
