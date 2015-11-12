using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour {
	public Color playerColor;
	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<Light> ().color = playerColor;
		gameObject.GetComponent<Crosshair> ().color = playerColor;
		gameObject.GetComponentInChildren<BodyBuilder> ().color = playerColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
