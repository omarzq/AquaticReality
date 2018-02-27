using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFish : MonoBehaviour {

	public GameObject fish;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - fish.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = fish.transform.position + offset;
	}
}
