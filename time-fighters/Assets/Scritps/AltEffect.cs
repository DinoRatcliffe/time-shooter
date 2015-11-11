using UnityEngine;
using System.Collections;

public class AltEffect : MonoBehaviour {

	public float lerp = 0.01F;
	private float currentLerp = 0F;
	private bool expand = false;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (0.3F, 0.3F, 0.3F);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localScale = Vector3.Lerp (gameObject.transform.localScale, new Vector3 (1F, 1F, 1F), currentLerp);
		if (expand) currentLerp += lerp;
	}

	public void activate() {
		gameObject.GetComponent<PhisicalObject> ().drag = 1;
		expand = true;
	}
}
