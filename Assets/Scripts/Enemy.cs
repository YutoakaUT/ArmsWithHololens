using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemy;
    public static int flag_AI = 0;
    public static int flag_AI2 = 0;

    private float attackInterval = 2f;
    private float attackInterval2 = 2f;
   // private float enemyRotationSmooth = 0.8f;
    private float lastAttackTime;
    private float lastAttackTime2;
 //   private Transform player;



    private void Start()
    {
        // 始めにプレイヤーの位置を取得できるようにする
      //  player = GameObject.FindWithTag("Player").transform;
        lastAttackTime += 1f;
    }

    private void Update()
    {
        // 砲台をプレイヤーの方向に向ける
        //Quaternion targetRotation = Quaternion.LookRotation(player.position - enemy.position);
        //enemy.rotation = Quaternion.Slerp(enemy.rotation, targetRotation, Time.deltaTime * enemyRotationSmooth);

        // 一定間隔で弾丸を発射する
        if (Time.time > lastAttackTime + attackInterval)
        {
            flag_AI = 1;
            lastAttackTime = Time.time;
        }
        // 一定間隔で弾丸を発射する
        if (Time.time > lastAttackTime2 + attackInterval2)
        {
            flag_AI2 = 1;
            lastAttackTime2 = Time.time;
        }
    }
}
