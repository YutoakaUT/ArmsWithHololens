using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "rightGrove_AI")
        {
            Destroy(this);
            HpBarCtrl.damage = -20;
        }
        //衝突判定
        if (collision.gameObject.tag == "leftGrove_AI")
        {
            Destroy(this);
            HpBarCtrl.damage = -20;
        }
        //衝突判定
        if (collision.gameObject.tag == "rightGrove_AI")
        {
            Destroy(this);
            HpBarCtrl.damage = -20;
        }
        //衝突判定
        if (collision.gameObject.tag == "leftGrove_AI")
        {
            Destroy(this);
            HpBarCtrl.damage = -20;
        }
    }
}
