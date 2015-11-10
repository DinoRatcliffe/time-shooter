using UnityEngine;
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
		player.transform.position = spawns [Random.Range (0, spawns.Length)].transform.position;
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
}
