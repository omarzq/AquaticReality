using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreAcc {
	private static ScoreAcc instance = null;
	public static ScoreAcc SharedInstance {
		get {
			if (instance == null) {
				instance = new ScoreAcc ();
			}
			return instance;
		}
	}
	public float score;
}