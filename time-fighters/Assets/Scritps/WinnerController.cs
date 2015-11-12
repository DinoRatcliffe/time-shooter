using UnityEngine;
using System.Collections;

public class WinnerController : MonoBehaviour {

	private GameObject[] players;
	private GameObject[] loserSpawns;
	private GameObject winnerSpawn;
	private GameObject winner;

	// Use this for initialization
	void Start () {
		loserSpawns = GameObject.FindGameObjectsWithTag ("Respawn");
		winnerSpawn = GameObject.FindGameObjectWithTag ("WinnerSpawn");
		int i = 0;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag ("Player")) {
			player.GetComponent<PlayerStatistics> ().setPlayerNumber (player.GetComponent<Controls>().playerNum);
			player.GetComponent<PlayerStatistics> ().UpdateStats();

			if (player.GetComponent<PlayerHealth>().currentLives > 0) {
				winner = player;
				player.transform.position = winnerSpawn.transform.localPosition;
				StartCoroutine (Respwan (player, winnerSpawn));
			} else {
				player.SetActive(true);
				StartCoroutine (Respwan (player, loserSpawns[i]));
				i++;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("READY_P" + winner.GetComponent<Controls> ().playerNum)) {
			Application.LoadLevel("Level Select");
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
