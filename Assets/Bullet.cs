using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject shoot;  //弾丸

	public Transform muzzle;  //射出場所

	public float speed = 5000;   //初速
	public float speed2 = 5000;   //初速

	private float distance1=0;   //フレーム間でのベクトル差分
	private float distance2=0;   //総移動距離
	private float flag=0;        //フラグ
	private float count=-1;

	private Vector3 t1Angle;
	private Vector3 t3Angle;
	private Vector3 t4Angle;


	void Start () {
		shoot.transform.position = muzzle.position;
	}
	

	void Update () {
		
		float step = speed2 * Time.deltaTime;
		t1Angle = muzzle.transform.position - shoot.transform.position;
		t4Angle = t4Angle - shoot.transform.position;
		distance1 = t1Angle.magnitude;
		distance2 += t4Angle.magnitude;
		t4Angle = shoot.transform.position;

		float angleDir = muzzle.transform.eulerAngles.y * (Mathf.PI / 180.0f);
		Vector3 dir = new Vector3 (Mathf.Cos (angleDir), Mathf.Sin (angleDir), -5.0f);
		t3Angle = muzzle.transform.forward-dir;

		if (flag == 0) {
			if (distance2 > 50) {
					flag = 1;
					distance2 = 0;
			}
			
<<<<<<< HEAD
		}   if (flag == 1) {
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, step/50);
=======
		}   if (flag == 1) {     //手の方へ帰ってくるとき
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, step/20);
>>>>>>> Punch2
			if (distance1 < 1) {
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				shoot.transform.position = muzzle.transform.position;
				flag = 2;
				count = 0;
			}
<<<<<<< HEAD
				
			
		}  if (flag == 2) {
=======
		}  if (flag == 2) {   //一度パンチが帰ってきた後の処理
>>>>>>> Punch2
			shoot.transform.position = muzzle.transform.position;
			count = 0;
			if (Input.GetKeyDown (KeyCode.Z)) {
				t4Angle = muzzle.transform.position;
				shoot.transform.position = muzzle.position;
				shoot.GetComponent<Rigidbody> ().AddForce (t3Angle.normalized * speed/5);
				flag = 0;
				distance2 = 0;
<<<<<<< HEAD
=======
		
>>>>>>> Punch2
			}
		}

<<<<<<< HEAD
		if (count==1) {
			if (shoot.transform.position.z-50 < muzzle.transform.position.z) {
=======
		if (count==1) {   //衝突回数が1を超えた時，球の1と発射口の位置との距離をとり始める
			if (shoot.transform.position.z-80 < muzzle.transform.position.z) {   //ｚ軸で位置判定
>>>>>>> Punch2
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				flag = 1;
				count = 0;
			}
		}
			

		if (Input.GetKeyDown (KeyCode.Z)) {
			count = 0;
			t4Angle = muzzle.transform.position;
			shoot.transform.position = muzzle.position;
			shoot.GetComponent<Rigidbody> ().AddForce (t3Angle.normalized * speed/5);
			distance2 = 0;


		}
	}
	void OnCollisionEnter(Collision other){
		count++;

		if(other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
			flag = 1;
			count = 0;
		}
	}
	void OnTrigerEnter(Collider other){
		shoot.transform.position = muzzle.transform.position;
		flag = 1;
	}

}