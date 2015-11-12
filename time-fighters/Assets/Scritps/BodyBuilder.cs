using UnityEngine;
using System.Collections;

public class BodyBuilder : MonoBehaviour {
	public int width;
	public int height;
	public int depth;
	public GameObject item;
	public Color color;

	// Use this for initialization
	void Start () {
		BoxCollider boxCollider = gameObject.GetComponentInParent<BoxCollider> ();
		gameObject.transform.localScale = new Vector3(boxCollider.size.x/height, boxCollider.size.y/width, boxCollider.size.z/depth);
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				for (int r = 0; r < depth; r++) {
					GameObject g = (GameObject) Instantiate(item, transform.position, transform.rotation);
					g.GetComponent<Renderer>().material.color = color;
					g.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
					g.GetComponentInChildren<Light>().color = color;
					g.transform.parent = transform;
					g.transform.localPosition = new Vector3(i-height/2, j-width/2, r-depth/2);
					g.transform.localScale = new Vector3(1F, 1F, 1F);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reform() {

	}

	IEnumerator Reform() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = GetComponent<Renderer>().material.color;
			c.a = f;
			GetComponent<Renderer>().material.color = c;
			yield return null;
		}
	}
}
