using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwimScript : MonoBehaviour {
	
	private bool swimming = false;
	private bool alive = true;
	private Vector3 spawn;
	public float speed;
	public int score;
	public static int finalScore;
	private Text deadText;
	private Rigidbody rb;
	private int health;
	private int trashCount;
	public List<Transform> trashList = new List<Transform>();
	private TextMesh scoreText;

	public float RateOfSpawn = 1;
	private float nextSpawn = 0;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("Score Text").GetComponent<TextMesh>();
		spawn = transform.position;
		trashCount = 30;
		health = 3;
		score = 0;
		speed = 0.5f;
	}

	// Update is called once per frame
	void Update () {
		
		if (alive) {
			if (swimming && Input.anyKey) {
				transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			}
		}

		if (transform.position.y < -10f) {
			transform.position = spawn;
		}

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("plane")) {
				swimming = false;
			} else { 
				swimming = true;
			}
		}
		scoreText.text = "Score: " + score.ToString ();
		if (alive == false) {
			finalScore = score;
			scoreText.characterSize = 1;
			scoreText.text = "Final Score: " + finalScore.ToString () +"\nPlease do not litter! \nOur fish friends do not appreciate it.";
			float start = Time.time;
			if (Input.anyKey)
				Invoke ("restart", 8);
			
		}
	}

	private IEnumerator delay() {
		yield return new WaitForSeconds(5f);
		// do something
	}

	private void restart() {
		SceneManager.LoadScene ("underwater");
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Fish")) {
			other.gameObject.SetActive (false);
			score += 100;
			speed += (speed * 0.15f);
			//scoreText.text = "Score: " + score.ToString();
			Debug.Log ("score", new GameObject());
			//su.updateScore (score);
		} else if (other.gameObject.CompareTag("Trash")) {
			alive = false;
		}
	}   
}