﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletForce = 600f;
	public float cleanUpAfter = 2f; //destroy object after n seconds
	// Use this for initialization
	void Start () {
		PhisicalObject po = GetComponent<PhisicalObject> ();
		po.AddForce (transform.right*bulletForce);
		Destroy (gameObject, 5F);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
