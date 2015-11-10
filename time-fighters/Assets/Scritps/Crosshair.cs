using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public GameObject projectile;
	public GameObject altProjectile;
	public GameObject crosshairPrefab;
	Vector2 aimingLocation;

	private GameObject crosshair;

	// Use this for initialization
	void Start () {
		crosshair = (GameObject) Instantiate (crosshairPrefab, new Vector3(0F, 0F, 0F), transform.rotation);
		crosshair.transform.parent = gameObject.transform;
	}

	public void Fire() {
		if (aimingLocation.magnitude > 0) {
			GameObject g = (GameObject)Instantiate (projectile, gameObject.transform.position, gameObject.transform.rotation);
			Projectile p = g.GetComponent<Projectile> ();
			p.shoot (aimingLocation.normalized);
			p.destroy (5F);
		}
	}

	public void AltFire() {
	}

	public void AltFireDeploy() {
	}

	public void AltFireClear() {
	}

	public void updateAimLocation(Vector2 aim) {
		aimingLocation = aim;
	}

	// Update is called once per frame
	void Update () {
		crosshair.transform.localPosition = aimingLocation;
	}
}
