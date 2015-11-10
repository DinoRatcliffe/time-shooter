using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeManipulationZone : MonoBehaviour {

	public float timeScale = 0.05F;
	private List<PhisicalObject> objects;


	// Use this for initialization
	void Start () {
		objects = new List<PhisicalObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = timeScale;
		objects.Add (collider.gameObject.GetComponent<PhisicalObject> ());
	}

	void OnTriggerExit(Collider collider) {
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = 1F;
		objects.Remove (collider.gameObject.GetComponent<PhisicalObject> ());
	}

	void OnDestroy() {
		foreach (PhisicalObject p in objects) {
			p.timeScale = 1F;
		}
	}
}
