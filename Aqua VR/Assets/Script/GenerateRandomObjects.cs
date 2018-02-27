using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObjects : MonoBehaviour {

	public int trashCount;
	public List<Transform> trashList = new List<Transform>();

	public float RateOfSpawn = 1f;
	private float nextSpawn = 0;

	void Start (){
		trashCount = 0;
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
			Transform trash = Instantiate(trashList[Random.Range(0, trashList.Count)], rndPosWithin, transform.rotation);
			Rigidbody rb = trash.gameObject.AddComponent<Rigidbody> ();
			rb.useGravity = false;
			rb.isKinematic = false;
			CapsuleCollider cc = trash.gameObject.AddComponent<CapsuleCollider> ();
			cc.isTrigger = true;
			cc.radius = 0.3f;
			cc.height = 0.5f;
			trash.tag = "Trash";

		}
	}
}
