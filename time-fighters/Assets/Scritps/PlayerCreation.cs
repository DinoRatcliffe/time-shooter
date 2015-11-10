using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerCreation : MonoBehaviour {
	public GameObject playerPrefab;
	public Vector3 p1_spawn, p2_spawn, p3_spawn, p4_spawn;
	public Color p1_color, p2_color, p3_color, p4_color;

	private bool p1Spawned, p2Spawned, p3Spawned, p4Spawned;
	private List<GameObject> players;
	private Text[] textualComponents;
	// Use this for initialization
	void Start () {
		players = new List<GameObject> ();
		textualComponents = gameObject.GetComponentsInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("START_P1") && !p1Spawned) {
			spawnPlayer(p1_spawn, 1, p1_color);
			p1Spawned = true;
			Application.LoadLevel("Level 1");
		} else if (Input.GetButtonDown ("START_P2") && !p2Spawned) {
			spawnPlayer(p2_spawn, 2, p2_color);
			p2Spawned = true;
		} else if (Input.GetButtonDown ("START_P3") && !p3Spawned){
			spawnPlayer(p3_spawn, 3, p3_color);
			p3Spawned = true;
		} else if (Input.GetButtonDown ("START_P4") && !p4Spawned) {
			spawnPlayer(p4_spawn, 4, p4_color);
			p4Spawned = true;
		}

	}

	void spawnPlayer(Vector3 location, int controllerNumber, Color color) {
		GameObject player = Instantiate(playerPrefab);
		player.transform.position = location;
		player.GetComponent<Controls>().setPlayerNum(controllerNumber);
		player.GetComponent<Renderer> ().material.color = color;
		players.Add(player);

		DontDestroyOnLoad (player.gameObject);

		foreach (Text t in textualComponents) {
			if (t.name == "P"+controllerNumber) {
				t.enabled = false;
			}
		}
	}
}
