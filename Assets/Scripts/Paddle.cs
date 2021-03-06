﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float minX, maxX;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3(8f,this.transform.position.y,0f);

		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);

		this.transform.position = paddlePos;
	}
}
