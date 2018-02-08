using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gradient : MonoBehaviour {

	//public GameObject myCube;

	// Use this for initialization
	void Update () {

		//gameObject取得 
		//myCube = GameObject.Find("CubeName");

		//今の色コンソールに出力
		Debug.Log(this.GetComponent<Renderer>().material.color);

		if (TimerFanc.timeflag == 1) {
			//色変更
			float tmp = 1.0f - (TimerFanc.countTime / StartToChange.wateTime);
			this.GetComponent<Renderer> ().material.color = new Color (tmp,tmp,tmp);
		}
		//変更後の色コンソールに出力
		Debug.Log(this.GetComponent<Renderer>().material.color);
	}
}
