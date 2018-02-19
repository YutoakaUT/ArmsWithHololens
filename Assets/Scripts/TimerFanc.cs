using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerFanc : MonoBehaviour {
	public static int timeflag;
	public static float countTime;

	// Use this for initialization
	void Start () {
		timeflag = 0; 
		countTime = 0;
		//gameflag = 0;
	}

	// Update is called once per frame
	void Update () {
		if (timeflag == 1) {
			countTime += Time.deltaTime; //スタートしてからの秒数を格納
			GetComponent<Text> ().text = countTime.ToString ("F2"); //小数2桁にして表示
		} else if (timeflag == 0) {
			countTime = 0;
		}
	}
}