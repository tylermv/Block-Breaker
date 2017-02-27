using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	public GameObject smoke;

	private int timesHit;
	private bool isBreakable;

	void Awake () {

	}
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
			}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col) {
		bool isBreakable = (this.tag == "Breakable"); 

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
			SmokePuff();
		} else {
			LoadSprites ();
		}
	}
	void SmokePuff() {
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
		main.startColor = GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
			}
		}
}