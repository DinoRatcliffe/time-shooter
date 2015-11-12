﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	private List<GameObject> players;
	private List<GameObject> inactivePlayers;
	private GameObject[] spawns;
	
	// Use this for initialization
	void Start () {
		players = new List<GameObject> ();
		inactivePlayers = new List<GameObject> ();

		spawns = GameObject.FindGameObjectsWithTag ("Respawn");
		int i = 0;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag ("Player")) {
			players.Add (player);
			player.GetComponent<PlayerHealth>().reset();
			player.transform.localPosition = spawns[i].transform.position;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(GameObject player) {
		StartCoroutine (Respwan (player, spawns [Random.Range (0, spawns.Length)]));
	}

	public void RemovePlayer(GameObject player) {
		players.Remove (player);
		inactivePlayers.Add (player);
		player.SetActive (false);
		if (players.Count == 1) {
			foreach (GameObject p in inactivePlayers) {
				p.SetActive(true);
			}
			Application.LoadLevel("ResultsScene");
		}
	}

	
	IEnumerator Respwan(GameObject player, GameObject spawn) {
		player.GetComponent<BoxCollider> ().enabled = false;
		player.GetComponent<Controls> ().enabled = false;
		player.GetComponent<PhisicalObject> ().enabled = false;

		foreach (Light l in player.GetComponentsInChildren<Light> ()) {
			l.enabled = false;
		}

		foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {
			p.GetComponentInChildren<Light>().enabled = true;
			p.scatter();
		}

		for (float f = 1f; f >= 0.1; f -= 0.01f) {
			yield return null;
		}


		Vector3 oldPosition = player.transform.position;
		player.transform.position = spawn.transform.position;

		foreach (Light l in player.GetComponentsInChildren<Light> ()) {
			l.enabled = true;
		}

		foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {		
			p.transform.position = p.transform.position + (oldPosition - player.transform.position);
			p.startReform();
		}

		for (float f = 0f; f <= 1; f += 0.01f) {
			foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {
				p.ReformLerp(f);
			}
			yield return null;
		}

		player.GetComponent<PhisicalObject> ().enabled = true;
		player.GetComponent<BoxCollider> ().enabled = true;
		player.GetComponent<Controls> ().enabled = true;
		foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {		
			p.GetComponentInChildren<Light>().enabled = false;
		}
	}
}
