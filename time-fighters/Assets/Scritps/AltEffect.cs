using UnityEngine;
using System.Collections;

public class AltEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (0.3F, 0.3F, 0.3F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate() {
		gameObject.GetComponent<PhisicalObject> ().drag = 1;
		gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
	}
}
