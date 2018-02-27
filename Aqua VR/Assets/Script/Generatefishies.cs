using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatefishies : MonoBehaviour {

	public List<Transform> fishList = new List<Transform>();
	public float RateOfSpawn = 0.4f;
	private float nextSpawn = 0;

	void Start (){
	}

	// Update is called once per frame
	void Update () {           
		if(Time.time > nextSpawn)
		{
			nextSpawn = Time.time + RateOfSpawn;

			// Random position within this transform
			Vector3 rndPosWithin;
			rndPosWithin = new Vector3(Random.Range(-4f, 4f), Random.Range(0, 2f), Random.Range(-4f, 4f));
			rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
			Transform fish = Instantiate(fishList[Random.Range(0, fishList.Count)], rndPosWithin, transform.rotation);
			fish.tag = "Trash";

		}
	}
}
