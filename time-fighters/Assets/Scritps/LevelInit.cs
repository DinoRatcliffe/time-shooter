using UnityEngine;
using System.Collections;

public class LevelInit : MonoBehaviour {

	private GameObject[] players;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] spawns = GameObject.FindGameObjectsWithTag ("Respawn");
		int i = 0;
		foreach (GameObject player in players) {
			player.transform.position = spawns[i].transform.position;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
