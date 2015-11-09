using UnityEngine;
using System.Collections;

public class TimeManipulationZone : MonoBehaviour {

	public float timeScale = 0.05F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = timeScale;
	}

	void OnTriggerExit(Collider collider) {
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = 1F;
	}
}
