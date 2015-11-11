using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {
	public int width;
	public int height;
	public GameObject item;
	public float speed;
	public float speedRange;

	private Dictionary<GameObject, float> items;

	// Use this for initialization
	void Start () {
		items = new Dictionary<GameObject, float> ();
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				GameObject g = (GameObject) Instantiate(item, transform.position, transform.rotation);
				g.transform.parent = transform;
				g.transform.localScale = new Vector3(1F, 1F, 1F);

				float initialSpeed = Random.Range (speed, speed+speedRange);
				float initialValue = Random.Range(0F, 1F);
				g.transform.localPosition = new Vector3(i-height/2, j-width/2, initialValue);

				if (Random.Range(0, 1) == 1) {
					initialSpeed *= -1;
				}

				items.Add (g, initialSpeed);
			}
		}
		
	}

	void FixedUpdate () {
		Dictionary<GameObject, float> newItems = new Dictionary<GameObject, float>();
		foreach (GameObject item in items.Keys) {
			float newZ = item.transform.localPosition.z;
			float newSpeed = items[item];

			newZ += items[item];

			if (Mathf.Sign(items[item]) > 0) {
				if (newZ > 1) {
					newZ = 1;
					newSpeed *= -1;
				}
			} else {
				if (newZ < 0) {
					newZ = 0;
					newSpeed *= -1;
				}
			}

			item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y, newZ);
			newItems.Add(item, newSpeed);
		}
		items = newItems;
	}
}
