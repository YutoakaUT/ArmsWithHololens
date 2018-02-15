using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public GameObject ExploadObj;
	public GameObject ExploadPos;
		// Update is called once per frame
	void Update () {
			//スペースキーを押したら
	}
	void OnCollisionEnter(Collision other){

			//エネミーに当たった時設定　
		if(other.gameObject.tag == "mato") {
			Instantiate (ExploadObj,ExploadPos.transform.position, Quaternion.identity);
			}
		}
	}