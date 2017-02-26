using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rigi;
	public AudioClip start;
	public AudioClip collision;
	public AudioSource volume;


	private void Awake() {
		rigi = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Lock the ball relative to the paddle
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

		//Launch the ball on click
		if (Input.GetMouseButtonDown (0)) {
			print ("Mouse has been clicked");
			hasStarted = true;
			this.rigi.velocity = new Vector2 (2f, 12f);
				if (hasStarted) {
				AudioSource.PlayClipAtPoint (start, transform.position);
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {
		AudioSource.PlayClipAtPoint (collision, transform.position);
			rigi.velocity += tweak;
			}
		}
	}

