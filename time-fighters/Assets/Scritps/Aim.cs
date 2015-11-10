using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	Vector3 mousePosition;
	Vector3 objectPosition;
	GameObject projectile;
	Transform targetting;

	Vector2 aimingLocation;

	// Use this for initialization
	void Start () {
		targetting = transform.FindChild ("targetting");
		projectile = Resources.Load ("aimtest/Projectile") as GameObject;
	}

	public void Fire() {
		Instantiate (projectile, targetting.position, targetting.rotation);
	}


	public void updateAimLocation(Vector2 aim) {
		aimingLocation = aim;
	}
	// Update is called once per frame
	void Update () {/*
		//for Mouse
		mousePosition = Input.mousePosition;
		objectPosition = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 result;
		result = mousePosition - objectPosition;
		*/
	
		float angle = Mathf.Atan2 (aimingLocation.y, aimingLocation.x) * Mathf.Rad2Deg;
		targetting.rotation = Quaternion.Euler (0, 0, angle);
	}
}
