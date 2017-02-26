using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSceneAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(GameObject.Find("MusicPlayer")); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
