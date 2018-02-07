using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

	// punch prefab
	public GameObject punch;

	// パンチ発射点
	public Transform Righthand;
	public Transform Lefthand;


	// 弾丸の速度
	public float speed;

	// 初期化
	void Start () {

	}

	// フレームごとに呼び出される
	void Update () {
		// M キーが押された時
		if (Input.GetKeyDown (KeyCode.M)) {
			// パンチの複製
			GameObject punchs = GameObject.Instantiate (punch)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			// Rigidbodyに力を加えて発射
			punchs.GetComponent<Rigidbody> ().AddForce (force);
			// パンチの位置を調整
			punchs.transform.position = Righthand.position;
		} 
		// Z キーが押された時
		if (Input.GetKeyDown (KeyCode.Z)) {
			// パンチの複製
			GameObject punchs = GameObject.Instantiate (punch)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			// Rigidbodyに力を加えて発射
			punchs.GetComponent<Rigidbody> ().AddForce (force);	
			// パンチの位置を調整
			punchs.transform.position = Lefthand.position;
		}
	}
}