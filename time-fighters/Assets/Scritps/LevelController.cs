using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	private List<GameObject> players;
	private List<GameObject> inactivePlayers;
	private GameObject[] spawns;

	public int targetKills = 5;
	
	// Use this for initialization
	void Start () {
		players = new List<GameObject> ();
		inactivePlayers = new List<GameObject> ();

		spawns = GameObject.FindGameObjectsWithTag ("Respawn");
		int i = 0;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag ("Player")) {
			players.Add (player);
			player.GetComponent<PlayerHealth>().reset();
			player.GetComponent<PlayerStatistics> ().setPlayerNumber (player.GetComponent<Controls>().playerNum);
			player.GetComponent<PlayerStatistics>().setLives(player.GetComponent<PlayerHealth>().currentLives);
			player.GetComponent<PlayerStatistics>().setKills(0);
			StartCoroutine (Respwan (player, spawns [i]));
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(GameObject player) {
		StartCoroutine (Respwan (player, spawns [Random.Range (0, spawns.Length)]));
		foreach (GameObject p in GameObject.FindGameObjectsWithTag ("Player")) {
			if (p.GetComponent<PlayerStatistics>().kills >= targetKills) {
				EndLevel();
			}
		}
	}

	void EndLevel () {
		foreach (GameObject p in inactivePlayers) {
			p.SetActive(true);
		}
		Application.LoadLevel ("ResultsScene");
	}

	public void RemovePlayer(GameObject player) {
		players.Remove (player);
		inactivePlayers.Add (player);
		player.SetActive (false);
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

		for (float f = 1f; f >= 0.1; f -= 0.05f) {
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

		for (float f = 0f; f <= 1; f += 0.05f) {
			foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {
				p.ReformLerp(f);
			}
			yield return null;
		}

		foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {
			p.ReformLerp(1);
		}

		player.GetComponent<PhisicalObject> ().enabled = true;
		player.GetComponent<BoxCollider> ().enabled = true;
		player.GetComponent<Controls> ().enabled = true;
		foreach (PlayerParticle p in player.GetComponentsInChildren<PlayerParticle>()) {		
			p.GetComponentInChildren<Light>().enabled = false;
		}
	}
}
