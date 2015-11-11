using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeManipulationZone : MonoBehaviour {

	public float timeScaleFactor = 0.5F;
	private Dictionary<GameObject, float> objects;


	// Use this for initialization
	void Start () {
		objects = new Dictionary<GameObject, float> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		float oldTime = collider.gameObject.GetComponent<PhisicalObject> ().timeScale;
		float timeDiff = oldTime * timeScaleFactor;
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = oldTime - timeDiff;
		objects.Add (collider.gameObject, timeDiff);
	}

	void OnTriggerExit(Collider collider) {
		float oldTime = collider.gameObject.GetComponent<PhisicalObject> ().timeScale;
		float timeDiff;
		objects.TryGetValue (collider.gameObject, out timeDiff);
		collider.gameObject.GetComponent<PhisicalObject> ().timeScale = oldTime + timeDiff;
		objects.Remove (collider.gameObject);
	}

	void OnDestroy() {
		foreach (GameObject g in objects.Keys) {
			float timeDiff;
			objects.TryGetValue(g, out timeDiff);

			if (g) {
				g.GetComponent<PhisicalObject>().timeScale += timeDiff;
			}
		}
	}
}
