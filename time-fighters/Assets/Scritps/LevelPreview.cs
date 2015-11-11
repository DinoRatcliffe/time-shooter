using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPreview : MonoBehaviour {

	public List<GameObject> levels;
	private int selected = 0;
	private GameObject currentLevel;
	private bool rightDown, leftDown;

	// Use this for initialization
	void Start () {
		refreshLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (new Vector3 (0, 0.5F, 0));

		float value = Input.GetAxis ("DPAD_HORIZONTAL_ALL");
		Debug.Log (value);
		if (value > 0 && !rightDown) {
			selected = selected + 1 > levels.Count - 1 ? 0 : selected + 1;
			refreshLevel ();
			rightDown = true;
			leftDown = false;
		} else if (value < 0 && !leftDown) {
			selected = selected >= 1 ? selected - 1 : levels.Count - 1;
			refreshLevel ();
			leftDown = true;
			rightDown = false;
		} else if (value == 0) {
			rightDown = false;
			leftDown = false;
		}

		if (Input.GetButtonDown ("READY_ALL")) {
			enterLevel ();
		}
	}

	void enterLevel() {
		Application.LoadLevel ("Level " + (selected + 1));
	}

	void refreshLevel() {
		if (currentLevel) Destroy (currentLevel);
		currentLevel = (GameObject) Instantiate(levels [selected]);
		currentLevel.transform.position = gameObject.transform.position;
		currentLevel.transform.rotation = gameObject.transform.rotation;
		currentLevel.transform.localScale = gameObject.transform.localScale;
		currentLevel.transform.parent = gameObject.transform;
	}
}
