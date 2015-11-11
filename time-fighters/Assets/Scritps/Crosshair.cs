using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public GameObject projectile;
	public GameObject altProjectilePrefab;
	public GameObject crosshairPrefab;
	Vector2 aimingLocation;
	public Color color;

	private GameObject crosshair;
	private GameObject currentAltProjectile;

	// Use this for initialization
	void Start () {
		crosshair = (GameObject) Instantiate (crosshairPrefab, new Vector3(0F, 0F, 0F), transform.rotation);
		crosshair.transform.parent = gameObject.transform;
	}

	public void Fire() {
		if (aimingLocation.magnitude > 0) {
			GameObject g = (GameObject)Instantiate (projectile, gameObject.transform.position, gameObject.transform.rotation);
			Projectile p = g.GetComponent<Projectile> ();
			p.GetComponentInChildren<Light>().color = color;
			p.GetComponent<Renderer>().material.color = color;
			p.GetComponent<Renderer>().material.SetColor ("_EmissionColor", color);
			p.shoot (aimingLocation.normalized, gameObject);
			p.destroy (5F);
		}
	}

	public void AltFire() {
		if (aimingLocation.magnitude > 0) {
			if (currentAltProjectile) AltFireClear();
			currentAltProjectile = (GameObject)Instantiate (altProjectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
			Projectile p = currentAltProjectile.GetComponent<Projectile> ();
			p.GetComponentInChildren<Light>().color = color;
			p.shoot (aimingLocation.normalized, gameObject);
		}
	}

	public void AltFireDeploy() {
		if (currentAltProjectile) {
			currentAltProjectile.GetComponent<AltEffect>().activate();
		}
	}

	public void AltFireClear() {
		if (currentAltProjectile) {
			currentAltProjectile.GetComponent<AltEffect>().destroy();
			currentAltProjectile = null;
		}
	}

	public void updateAimLocation(Vector2 aim) {
		aimingLocation = aim;
	}

	// Update is called once per frame
	void Update () {
		crosshair.transform.localPosition = aimingLocation;
	}
}
