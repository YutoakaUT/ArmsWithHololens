using System.Collections.Generic;
using UnityEngine;

public class LeftGlove : MonoBehaviour {

	public GameObject shoot;  //弾丸
	public Transform muzzle;  //射出場所
	public int distancelimit = 60;  //移動距離制限

	public float speed = 5000;   //初速
	private float distance1=0;   //フレーム間でのベクトル差分長
	private float distance2=0;   //総移動距離
	private float startTime;  //時間経過
	private float angle = 0.0F;        //Gloveの回転調整

	private int flag = -1;        //フラグ(0の時がパンチが射出している時）
	private int count = 0;    //衝突回数
	private int flag_right = 1; 

	private Vector3 t1Angle;   //muzzleとshootの位置ベクトル差分
	private Vector3 t2Angle;   //muzzleとshootの向きベクトル差分
	private Vector3 t3Angle;   //muzzleの座標格納
	private Vector3 t4Angle;   //shootの座標格納
	private Vector3 tz1Angle;   //右グローブ用
	private Vector3 tz2Angle;   //左グローブ用
	private Vector3 hitPos1;   //1度目に当たった座標を格納

	private Vector3 curve= new Vector3(3,-8,3);//右グローブの軌道調整用
	private Vector3 axis = Vector3.zero;  //Gloveの回転調整

	public AudioClip clip1;   //効果音
	public AudioClip clip2;   //効果音


	void Start () {
		shoot.transform.position = muzzle.position;    //初期位置調整
		startTime = 0;
	}

	void Update () {
		t1Angle = muzzle.transform.position - shoot.transform.position;
		t2Angle = shoot.transform.forward - muzzle.transform.forward;
		t2Angle = t2Angle.normalized;
		t3Angle = muzzle.transform.forward;
		t4Angle = t4Angle - shoot.transform.position;
		distance1 = t1Angle.magnitude;     
		distance2 += t4Angle.magnitude;   //総移動距離の計算
		t4Angle = shoot.transform.position;

		tz1Angle = new Vector3 (t3Angle.x, 0,0);
		tz1Angle = t3Angle + tz1Angle;
		startTime += Time.deltaTime;  //時間経過を計測

		muzzle.rotation.ToAngleAxis (out angle, out axis);   //muzzleの回転を取得
		shoot.transform.rotation = Quaternion.AngleAxis(angle, axis);  //Gloveに回転を代入
		shoot.transform.Rotate(new Vector3(90,0,0));   //Gloveの向きを90度回転

		if (flag != -1 && startTime > 2) {   //発射されてから2秒経過後
			shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;   //加速度0
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, distancelimit / distance1);
			flag=1;
		}

		if (flag == -1 ) {  //スタート時
			shoot.transform.position = muzzle.transform.position;
			count = 0;
			if (Input.GetMouseButton(0)||Input.GetMouseButton(2)||Input.GetKeyDown(KeyCode.Z)){  //最初の射出時用
				if (flag_right == 1) {
					
					shoot.transform.position = muzzle.transform.position;
					t4Angle = muzzle.transform.position;
					startTime = 0;
					count = 0;
					distance2 = 0;
					flag = 0;
					flag_right = 0;
					if (shoot.transform.forward.normalized.x > 0) {  //右の壁に向かってパンチを射出した場合
						shoot.GetComponent<Rigidbody> ().AddForce (t3Angle.normalized * speed / 5);
					} else {
						shoot.GetComponent<Rigidbody> ().AddForce (tz1Angle.normalized * speed / 5);  //腕が向いている方向に射出 
					}
					//AudioSource.PlayClipAtPoint (clip2, t2Angle);//音
				}
			}
		}

		if (flag == 0) {  //パンチが壁に向かって放たれている時
			Vector3 v = shoot.GetComponent<Rigidbody> ().velocity;//現在の速度を取得
			Vector3 cross = Vector3.Cross (v, curve); 
			shoot.GetComponent<Rigidbody> ().AddForce (cross * 0.1f);  //カーブを描くように速度に応じた力を加える

			if (distance2 > distancelimit || v.magnitude < 20) {     //総移動距離が50以上の時フラグ
				flag = 1;
			}
		}

		if (flag == 1) {     //パンチが手の方へ帰ってくる時
			shoot.transform.position = Vector3.MoveTowards (shoot.transform.position, muzzle.transform.position, distancelimit / distance1);
			if (distance1 < 1) { //パンチと腕の距離がほぼ0の時
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;   //加速度0
				shoot.transform.position = muzzle.transform.position;  //初期位置に戻す
				flag = -1;
				count = 0;
				flag_right = 1;
			}
		}  

		if (count >= 1) {  //壁の衝突回数が1以上の場合
			if (shoot.transform.forward.normalized.x <= 0) {  //左の壁に向かってパンチを射出した場合（特殊動作）
				shoot.transform.LookAt (-hitPos1);
				shoot.transform.Rotate(new Vector3(90,5,0)); 
			}
			if (distance2 > distancelimit || flag == 2) {   //制限距離より大きくなった時，壁にヒットした場所に向かう
				if (flag < 2) {
					shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;   //加速度0
					flag = 2;
				}
				if (flag == 2) {
					shoot.GetComponent<Rigidbody> ().AddForce (-(shoot.transform.position - hitPos1).normalized * speed / 80); 
					if ((shoot.transform.position - hitPos1).magnitude < 3) {  //壁との距離が近くなったらプレイヤーの元へ移動
						shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero; 
						flag = 1;
						count = 0;
					}
				}
			}
		}

	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "mato") {  //マトに当たった場合，そのまま戻る
			shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			if (count >= 1) {  //もし既に壁に当たっていた場合
				flag = 2;
			} else {
				flag = 1;
				count = 0;
			}
		}
		if (other.gameObject.tag == "wall") { //壁に当たった場合，カウントする
			count++;
			if(count == 1){
				foreach (ContactPoint point in other.contacts) {  
					hitPos1 = point.point;  //衝突した座標を検出
				}
			}else if(count >= 2){
				shoot.GetComponent<Rigidbody> ().velocity = Vector3.zero;  //2回以上当たった場合はすぐに戻る
			}
			AudioSource.PlayClipAtPoint (clip1, muzzle.transform.position);//音
		}

	}
	void OnTrigerEnter(Collider other){
		shoot.transform.position = muzzle.transform.position;
		flag = -1;
		flag_right = 1;
	}
}