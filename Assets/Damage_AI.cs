using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_AI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "rightGrove")
        {

            HpBarCtrl2.damage2 = 10;
        }
        //衝突判定
        if (collision.gameObject.tag == "leftGrove")
        {

            HpBarCtrl2.damage2 = 10;
        }
    }
}
