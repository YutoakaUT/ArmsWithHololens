using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Gradient : MonoBehaviour {

	//public GameObject myCube;
	int collisionFrag=0;
    internal int colorKeys;

    // Use this for initialization
    void Update () {

		//gameObject取得 
		//myCube = GameObject.Find("CubeName");

		//今の色コンソールに出力
		//Debug.Log(this.GetComponent<Renderer>().material.color);

		if ((TimerFanc.timeflag == 1)&&(collisionFrag == 1)) {
			//色変更
			float tmp = 1.0f - (TimerFanc.countTime / SceneChange.wateTime);
			this.GetComponent<Renderer> ().material.color = new Color (tmp,tmp,tmp);
		}
		//変更後の色コンソールに出力
		//Debug.Log(this.GetComponent<Renderer>().material.color);
	}

	void OnCollisionStay(Collision collision){

		//switchタグが付いたObjectと触れたら起動
		if(collision.gameObject.tag == "finger" ){
			collisionFrag = 1;
		}
		else{
			//それ以外の処理

		}
	}

	void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag == "finger"){
			this.GetComponent<Renderer> ().material.color = new Color (1.0f,1.0f,1.0f);
			collisionFrag = 0;
		}
	}

    internal void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys)
    {
        throw new NotImplementedException();
    }

    internal Color Evaluate(float v)
    {
        throw new NotImplementedException();
    }

    public static implicit operator UnityEngine.Gradient(Gradient v)
    {
        throw new NotImplementedException();
    }
}
