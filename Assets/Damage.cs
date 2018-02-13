<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

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
           
            HpBarCtrl.damage = 10;
        }
        //衝突判定
        if (collision.gameObject.tag == "leftGrove_AI")
        {

            HpBarCtrl.damage = 10;
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

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
           
            HpBarCtrl.damage = 10;
        }
        //衝突判定
        if (collision.gameObject.tag == "leftGrove_AI")
        {

            HpBarCtrl.damage = 10;
        }
    }
}
>>>>>>> 57527214b2d49211e72238e33fbb6580772b45dd
