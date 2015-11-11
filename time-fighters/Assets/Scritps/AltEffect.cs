using UnityEngine;
using System.Collections;

public class AltEffect : MonoBehaviour {

	public float lerp = 0.01F;
	private float currentLerp = 0F;
	private bool expand = false;

	// Use this for initialization
	void Start () {
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

	public void destroy() {
		StartCoroutine ("Shrink");
	}

	IEnumerator Shrink() {
		Vector3 scale = gameObject.transform.localScale;
		for (float f = 0f; f <= 1; f += 0.1f) {
			gameObject.transform.localScale = Vector3.Lerp (scale, new Vector3 (0F, 0F, 0F), f);
			yield return null;
		}

		Destroy (gameObject);
	}
}
