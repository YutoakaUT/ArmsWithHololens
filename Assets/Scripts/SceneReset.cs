﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Target_making.targetz.Clear();
            SceneManager.LoadScene ("OP");
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
           // Application.LoadLevel("OP");
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
        }
        }
}
