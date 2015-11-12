using UnityEngine;
using System.Collections;

public class PlayerHealth: MonoBehaviour {
	public int playerHealth = 100;
	public int playerLives = 1;

	private int currentHealth;
	public int currentLives;
	// Use this for initialization
	void Start () {
		currentHealth = playerHealth;
		currentLives = playerLives;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		Projectile p = collider.gameObject.GetComponent<Projectile> ();
		if (p && p.shooter != gameObject) {
			currentHealth -= p.damage;
			p.damagedPlayer();
		}

		if (currentHealth <= 0) {
			currentLives--;
			if (currentLives > 0) {
				currentHealth = playerHealth;
				GameObject.FindGameObjectWithTag ("LevelController").GetComponent<LevelController>().RespawnPlayer(gameObject);
			} else {
				GameObject.FindGameObjectWithTag ("LevelController").GetComponent<LevelController>().RemovePlayer(gameObject);
			}
		}
		GetComponent<PlayerStatistics> ().setLives(currentLives);
	}

	public void reset() {
		currentHealth = playerHealth;
		currentLives = playerLives;
	}

}
