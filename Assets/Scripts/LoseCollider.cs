using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionsEnter2D (Collision2D collision) {
		print ("Collision");
	}
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
		levelManager.LoadLevel ("Lose_screen");
	}



}
