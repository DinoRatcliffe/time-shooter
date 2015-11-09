using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	Vector3 mousePosition;
	Vector3 objectPosition;
	GameObject projectile;
	Transform targetting;

	// Use this for initialization
	void Start () {
		targetting = transform.FindChild ("targetting");
		projectile = Resources.Load ("aimtest/Projectile") as GameObject;
	}

	void Fire() {
		Instantiate (projectile, targetting.position, targetting.rotation);
	}
	
	// Update is called once per frame
	void Update () {/*
		//for Mouse
		mousePosition = Input.mousePosition;
		objectPosition = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 result;
		result = mousePosition - objectPosition;
		*/

		float x = Input.GetAxis ("AimHorizontal");
		float y = Input.GetAxis ("AimVertical");
		float angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
		targetting.rotation = Quaternion.Euler (0, 0, angle);

		if (Input.GetMouseButtonDown (0) || Input.GetButtonDown ("Fire1")) {
			Fire ();
		}
	}
}
