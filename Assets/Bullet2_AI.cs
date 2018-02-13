<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2_AI : MonoBehaviour
{

    public GameObject shoot;  //弾丸

    public Transform muzzle;  //射出場所

    public Transform ring;

    public float speed = 5000;   //初速
    public float speed2 = 5000;   //初速

    private float distance1 = 0;   //フレーム間でのベクトル差分長
    private float distance2 = 0;   //総移動距離
    private float flag = 0;        //フラグ
    private float count = -1;    //衝突回数

    private Vector3 t1Angle;   //muzzleとshootのベクトル差分
    private Vector3 t3Angle;   //muzzleの座標格納
    private Vector3 t4Angle;   //shootの座標格納
    private int flag_right = 1; //パンチのフラグ

    void Start()
    {
        shoot.transform.position = muzzle.position;    //位置調整
    }


    void Update()
    {

        float step = speed2 * Time.deltaTime;
        t1Angle = muzzle.transform.position - shoot.transform.position;
        t4Angle = t4Angle - shoot.transform.position;
        distance1 = t1Angle.magnitude;
        distance2 += t4Angle.magnitude;   //総移動距離の計算
        t4Angle = shoot.transform.position;
        t3Angle = muzzle.transform.forward;

        /*ここからうでを伸ばす機能
		Vector3 scale = t1Angle;
		scale.x = 1;
		ring.transform.forward = t1Angle;
		ring.transform.localScale = scale;
		ここまで*/


        if (flag == 0)
        {
            if (distance2 > 50)
            {     //総移動距離が50以上の時フラグ
                flag = 1;
                distance2 = 0;
            }

        }
        if (flag == 1)
        {     //手の方へ帰ってくるとき
            shoot.transform.position = Vector3.MoveTowards(shoot.transform.position, muzzle.transform.position, step / 20);
            if (distance1 < 1)
            {
                shoot.GetComponent<Rigidbody>().velocity = Vector3.zero;   //加速度0
                shoot.transform.position = muzzle.transform.position;  //初期位置に戻す
                flag = 2;
                count = 0;
            }
        }
        if (flag == 2)
        {   //一度パンチが帰ってきた後の処理
            shoot.transform.position = muzzle.transform.position;
            count = 0;
            flag_right = 1;
            if (Enemy.flag_AI2==1)
            {
                if (flag_right == 1)
                {
                    t4Angle = muzzle.transform.position;
                    shoot.transform.position = muzzle.position;
                    shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 5);
                    flag = 0;
                    distance2 = 0;
                    Enemy.flag_AI2 = 0;
                    flag_right = 0;
                }
            }
        }

        if (count == 1)
        {   //衝突回数が1を超えた時，球の1と発射口の位置との距離をとり始める
            if (shoot.transform.position.z - 80 < muzzle.transform.position.z)
            {   //ｚ軸で位置判定
                shoot.GetComponent<Rigidbody>().velocity = Vector3.zero;
                flag = 1;
                count = 0;
            }
        }


        if (Enemy.flag_AI2 == 1)
        {    //Zキーが押された時
            if (flag_right == 1)
            {
                shoot.transform.position = muzzle.transform.position;
                t4Angle = muzzle.transform.position;

                count = 0;
                shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 6);  //腕が向いている方向に射出
                distance2 = 0;
                flag = 0;
                Enemy.flag_AI2 = 0;
                flag_right = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        count++;

        /*エネミーに当たった時設定　
		if(other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
			flag = 1;
			count = 0;
		}
		ここまで*/
    }
    void OnTrigerEnter(Collider other)
    {
        shoot.transform.position = muzzle.transform.position;
        flag = 1;
    }



=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2_AI : MonoBehaviour
{

    public GameObject shoot;  //弾丸

    public Transform muzzle;  //射出場所

    public Transform ring;

    public float speed = 5000;   //初速
    public float speed2 = 5000;   //初速

    private float distance1 = 0;   //フレーム間でのベクトル差分長
    private float distance2 = 0;   //総移動距離
    private float flag = 0;        //フラグ
    private float count = -1;    //衝突回数

    private Vector3 t1Angle;   //muzzleとshootのベクトル差分
    private Vector3 t3Angle;   //muzzleの座標格納
    private Vector3 t4Angle;   //shootの座標格納
    private int flag_right = 1; //パンチのフラグ

    void Start()
    {
        shoot.transform.position = muzzle.position;    //位置調整
    }


    void Update()
    {

        float step = speed2 * Time.deltaTime;
        t1Angle = muzzle.transform.position - shoot.transform.position;
        t4Angle = t4Angle - shoot.transform.position;
        distance1 = t1Angle.magnitude;
        distance2 += t4Angle.magnitude;   //総移動距離の計算
        t4Angle = shoot.transform.position;
        t3Angle = muzzle.transform.forward;

        /*ここからうでを伸ばす機能
		Vector3 scale = t1Angle;
		scale.x = 1;
		ring.transform.forward = t1Angle;
		ring.transform.localScale = scale;
		ここまで*/


        if (flag == 0)
        {
            if (distance2 > 50)
            {     //総移動距離が50以上の時フラグ
                flag = 1;
                distance2 = 0;
            }

        }
        if (flag == 1)
        {     //手の方へ帰ってくるとき
            shoot.transform.position = Vector3.MoveTowards(shoot.transform.position, muzzle.transform.position, step / 20);
            if (distance1 < 1)
            {
                shoot.GetComponent<Rigidbody>().velocity = Vector3.zero;   //加速度0
                shoot.transform.position = muzzle.transform.position;  //初期位置に戻す
                flag = 2;
                count = 0;
            }
        }
        if (flag == 2)
        {   //一度パンチが帰ってきた後の処理
            shoot.transform.position = muzzle.transform.position;
            count = 0;
            flag_right = 1;
            if (Enemy.flag_AI2==1)
            {
                if (flag_right == 1)
                {
                    t4Angle = muzzle.transform.position;
                    shoot.transform.position = muzzle.position;
                    shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 5);
                    flag = 0;
                    distance2 = 0;
                    Enemy.flag_AI2 = 0;
                    flag_right = 0;
                }
            }
        }

        if (count == 1)
        {   //衝突回数が1を超えた時，球の1と発射口の位置との距離をとり始める
            if (shoot.transform.position.z - 80 < muzzle.transform.position.z)
            {   //ｚ軸で位置判定
                shoot.GetComponent<Rigidbody>().velocity = Vector3.zero;
                flag = 1;
                count = 0;
            }
        }


        if (Enemy.flag_AI2 == 1)
        {    //Zキーが押された時
            if (flag_right == 1)
            {
                shoot.transform.position = muzzle.transform.position;
                t4Angle = muzzle.transform.position;

                count = 0;
                shoot.GetComponent<Rigidbody>().AddForce(t3Angle.normalized * speed / 6);  //腕が向いている方向に射出
                distance2 = 0;
                flag = 0;
                Enemy.flag_AI2 = 0;
                flag_right = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        count++;

        /*エネミーに当たった時設定　
		if(other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
			flag = 1;
			count = 0;
		}
		ここまで*/
    }
    void OnTrigerEnter(Collider other)
    {
        shoot.transform.position = muzzle.transform.position;
        flag = 1;
    }



>>>>>>> 57527214b2d49211e72238e33fbb6580772b45dd
}