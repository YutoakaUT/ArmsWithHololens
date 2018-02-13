using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	string scenename;
	public static float wateTime=3.0f;

	// Use this for initialization
	void Start () {
		//待機時間決定
		//wateTime = 3.0f;
	}

	// Update is called once per frame
	void Update () {

		//3秒経過したらscenename（Object名）のSceneにとぶ
		if(TimerFanc.countTime>=wateTime){
		 SceneManager.LoadScene (scenename);
		 TimerFanc.timeflag = 0;
   		 TimerFanc.countTime = 0;
		}	

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Start");
		}
	}

	void OnCollisionStay(Collision collision){

		//switchタグが付いたObjectと触れたら起動
		if(collision.gameObject.tag == "switch" ){
			TimerFanc.timeflag = 1;
			scenename = collision.gameObject.name; //scenenameにObject名を保存
		}
		else{
			//それ以外の処理

		}
	}

	void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag == "switch"){
			TimerFanc.countTime = 0;
			TimerFanc.timeflag = 0;
		
			scenename = null;
		}
	}
}