using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwim : MonoBehaviour {

	private Rigidbody rb;
	int rotat, y;
	Vector3 direction;
	float speed;

	// Use this for initialization
	void Start () {
		calc ();
	}

	// Update is called once per frame
	void Update () {
		//transform.position = transform.position + Camera.main. * .5f * Time.deltaTime;
		//transform.RotateAround (Vector3.up, Vector3.up, Time.deltaTime*5);

		if (Time.frameCount % 60 == 0)
			calc ();
		transform.Rotate(direction, Time.deltaTime*rotat);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void calc(){
		y = Random.Range (0, 10);
		if (y % 2 == 0)
			direction = Vector3.up;
		else
			direction = Vector3.down;
		rotat = Random.Range (5, 60);
		speed = Random.Range (0.1f, 0.9f);
	}
}
