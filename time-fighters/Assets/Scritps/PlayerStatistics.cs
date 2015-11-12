using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour {

	Text statsText;
	private int lives;
	private int kills;
	private int playerNumber;

	// Use this for initialization
	void Start () {
	
	}

	public void setPlayerNumber(int playerNumber) {
		this.playerNumber = playerNumber;
		string statsField = "/PlayerStatsCanvas/P" + playerNumber + "/StatsText";

		GameObject obj = GameObject.Find (statsField);
		if (obj) {
			Debug.LogError ("Did FIND!");
			statsText = obj.GetComponent<Text> ();
		} else {
			Debug.LogError ("Could not find " + statsField);
		}
	}

	public void setLives(int lives) {
		this.lives = lives;
		UpdateStats ();
	}

	public void setKills(int kills) {
		this.kills = kills;
		UpdateStats ();
	}

	void UpdateStats() {
		if (statsText) {
			statsText.text = 
				"Player " + playerNumber + "\n" + 
				"Lives: " + this.lives + "\n" +
				"Kills: " + this.kills;
		} else {
			Debug.LogError ("Stats Text has not yet been initialized");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
