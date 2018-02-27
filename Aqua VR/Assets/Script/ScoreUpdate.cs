using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour {

	public static TextMesh scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("Score Text").GetComponent<TextMesh>();
		scoreText.text = "Score: 0";
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score.ToString ();
	}

	public void updateScore (int x){
		Debug.Log (x, new GameObject()); 
		scoreText.text = "Score: " + x.ToString();
		Debug.Log (scoreText.text);
	}
}
