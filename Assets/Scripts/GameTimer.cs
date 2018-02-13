using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

	public int inputLimit;
	public static int timeLimit;
	public string nextscene;

	// Use this for initialization
	void Start () {
		timeLimit = inputLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("s")) {
			TimerFanc.timeflag = 1;
			//TimerFanc.gameflag = 1;
			TimerFanc.countTime = 0;
		}
		if (TimerFanc.countTime >= inputLimit) {
			TimerFanc.timeflag = 0;
			//TimerFanc.gameflag = 0;
			TimerFanc.countTime = 0;
			SceneManager.LoadScene (nextscene);
		}
	}
}
