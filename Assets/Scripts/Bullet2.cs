using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour {

	public GameObject shoot;  //弾丸

	public Transform muzzle;  //射出場所

	public float speed = 5000;   //初速
	public float speed2 = 5000;   //初速

	private float distance1=0;   //フレーム間でのベクトル差分長
	private float distance2=0;   //総移動距離
	private float flag=-1;        //フラグ
	private float count=0;    //衝突回数

	private Vector3 t1Angle;   //muzzleとshootの位置ベクトル差分
	private Vector3 t2Angle;   //muzzleとshootの向きベクトル差分
	private Vector3 t3Angle;   //muzzleの座標格納
	private Vector3 t4Angle;   //shootの座標格納
	private Vector3 tz1Angle;   //右グローブ用
	private Vector3 tz2Angle;   //左グローブ用
	private int flag_right = 1; 

	private float startTime;

	Vector3 a= new Vector3(0,3,0);//右グローブの回転速度



	void Start () {
		shoot.transform.position = muzzle.position;    //位置調整
		startTime = Time.time;
	}


	void Update () {

		//float step = speed2 * Time.deltaTime;
		t1Angle = muzzle.transform.position - shoot.transform.position;
		t4Angle = t4Angle - shoot.transform.position;
		distance1 = t1Angle.magnitude;     
		distance2 += t4Angle.magnitude;   //総移動距離の計算
		t4Angle = shoot.transform.position;
		t3Angle = muzzle.transform.forward;
		t2Angle = shoot.transform.forward - muzzle.transform.forward;
		t2Angle = t2Angle.normalized;
		tz1Angle = new Vector3 (t3Angle.x+30, 0,0);
		tz2Angle = new Vector3 (t3Angle.x-30, 0,0);




		if (flag == -1) {
			shoot.transform.position = muzzle.transform.position;
		}
		/*ここからうでを伸ばす機能
		Vector3 scale = t1Angle;
		scale.x = 1;
		ring.transform.forward = t1Angle;
		ring.transform.localScale = scale;
		ここまで*/

		if (count == 2) {   //衝突回数が1を超えた時，球の位置と発射口の位置との距離をとり始める
			shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			if (t2Angle.z > 0.3 || t2Angle.z < -0.3 || t2Angle.x > 0.3 || t2Angle.x < -0.3) {
				flag = 1;
				count = 0;
			}
			if (shoot.transform.position.z-80 < muzzle.transform.position.z || shoot.transform.position.z+10 > muzzle.transform.position.z  || shoot.transform.position.x-20 < muzzle.transform.position.z || shoot.transform.position.x+20 > muzzle.transform.position.z) {   //ｚ軸で位置判定
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				flag = 1;
				count = 0;
			}
		}

		if (flag == 0) {  

			Vector3 v = shoot.GetComponent<Rigidbody>().velocity;//現在の速度を取得
			Vector3 cro = Vector3.Cross(v, a); 
			shoot.GetComponent<Rigidbody>().AddForce(cro * 0.1f);

			if (distance2 > 45) {     //総移動距離が50以上の時フラグ
				flag = 1;
				distance2 = 0;
			}

		}   if (flag == 1) {     //手の方へ帰ってくるとき
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, 50/distance1);
			if (distance1 < 1) {
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;   //加速度0
				shoot.transform.position = muzzle.transform.position;  //初期位置に戻す
				flag = 2;
				count = 0;
			}
		}  if (flag == 2) {   //一度パンチが帰ってきた後の処理
			shoot.transform.position = muzzle.transform.position;
			count = 0;
			flag_right = 1;
			if (Input.GetKeyDown (KeyCode.X)) {
				if (flag_right == 1)
				{
					t4Angle = muzzle.transform.position;
					shoot.transform.position = muzzle.position;

					shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 5);
					//右手用
					shoot.GetComponent<Rigidbody>().AddForce(tz1Angle * speed / 1000);
					//左手用
					//shoot.GetComponent<Rigidbody>().AddForce(tz2Angle * speed / 1000);
					flag = 0;
					distance2 = 0;
					flag_right = 0;
				}
			}
		}  

		if (count==1 && distance2>45 ) {   //衝突回数が1を超えた時，球の位置と発射口の位置との距離をとり始める
			if (t2Angle.z > 0.3 || t2Angle.z < -0.3 || t2Angle.x > 0.3 || t2Angle.x < -0.3) {
				flag = 1;
				count = 0;
			}
			if (shoot.transform.position.z-80 < muzzle.transform.position.z || shoot.transform.position.z+10 > muzzle.transform.position.z  || shoot.transform.position.x-20 < muzzle.transform.position.z || shoot.transform.position.x+20 > muzzle.transform.position.z) {   //ｚ軸で位置判定
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				flag = 1;
				count = 0;
			}
		}


		if (Input.GetKeyDown (KeyCode.X)) {    //Xキーが押された時
			if (flag_right == 1)
			{
				shoot.transform.position = muzzle.transform.position;
				t4Angle = muzzle.transform.position;
				count = 0;

				shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 5);  //腕が向いている方向に射出
				//右手用
				shoot.GetComponent<Rigidbody>().AddForce(tz1Angle * speed / 1000);
				//左手用
				//shoot.GetComponent<Rigidbody>().AddForce(tz2Angle * speed / 1000);

				distance2 = 0;
				flag = 0;
				flag_right = 0;

			}
		}
	}
	void OnCollisionEnter(Collision other){
		count++;

		//エネミーに当たった時設定　
		if(other.gameObject.tag == "mato") {
			flag = 1;
			count = 0;
		}
		//ここまで
		distance1 = t1Angle.magnitude;
		if (distance1 < 50) {   //ｚ軸で位置判定
			flag = 1;
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, 50 / distance1);
			count = 0;
		}
		if (shoot.transform.position.z-10 < muzzle.transform.position.z || shoot.transform.position.z+10 > muzzle.transform.position.z  || shoot.transform.position.x-10 < muzzle.transform.position.z || shoot.transform.position.x+10 > muzzle.transform.position.z) {   //ｚ軸で位置判定
			shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			flag = 1;
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, 50/distance1);
			count = 0;
		}
	}
	void OnTrigerEnter(Collider other){
		shoot.transform.position = muzzle.transform.position;
		flag = 1;
	}
}