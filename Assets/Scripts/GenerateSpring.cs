using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpring : MonoBehaviour {

	public GameObject springPrefab;
	public GameObject grove;
	public GameObject arm;
	public float maxNum;
	public float springsize;

	GameObject[] temp ;
	int n;
	Vector3 grovePos;
	Vector3 armPos;

	// Use this for initialization
	void Start () {
		temp = new GameObject[(int)maxNum];
        var parent = this.transform;
	
		for (n = 0; n < maxNum; n++) {

			temp[n] = (GameObject)Instantiate (springPrefab,new Vector3(0,0,0),Quaternion.identity,parent);
            //temp[n] = (GameObject)Instantiate(springPrefab);
            //temp[n].transform.localScale = new Vector3(springsize, springsize, springsize);
		}
	}

	// Update is called once per frame
	void Update () {

		grovePos = grove.transform.position;
		armPos = arm.transform.position;
		Vector3 minPos = (grovePos - armPos) / (maxNum + 1.0f);
		for (n = 0; n < maxNum; n++) {
			Vector3 thisPos = minPos * n;
			temp[n].transform.localScale = new Vector3( springsize, springsize, springsize);
			temp[n].transform.position = thisPos + armPos;
			//temp[n].transform.LookAt( grovePos );
			//temp[n].transform.Rotate(new Vector3(0.0f, 90.0f, 90.0f));
		}
       this.transform.LookAt(grovePos);
	}
}
