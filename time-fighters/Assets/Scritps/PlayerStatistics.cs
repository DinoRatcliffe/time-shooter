using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour {

	GameObject statsCanvas;
	private int health;
	private int kills;

	// Use this for initialization
	void Start () {
	
	}

	public void setHealth(int health) {
		this.health = health;
		UpdateStats ();
	}

	public void setKills(int kills) {
		this.kills = kills;
		UpdateStats ();
	}

	void UpdateStats() {
		Text statsText = statsCanvas.GetComponent<Text> ();
		statsText.text = 
			"Health: " + this.health + "\n" +
			"Kills: " + this.kills;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
