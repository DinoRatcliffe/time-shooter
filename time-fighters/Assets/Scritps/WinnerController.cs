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
			if (player.GetComponent<PlayerHealth>().currentLives > 0) {
				winner = player;
				player.transform.position = winnerSpawn.transform.localPosition;
			} else {
				player.SetActive(true);
				player.transform.localPosition = loserSpawns[i].transform.position;
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
}
