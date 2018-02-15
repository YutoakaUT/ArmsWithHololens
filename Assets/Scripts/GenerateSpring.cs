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

	Vector3 player;
	Vector3 subCamera;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform.position;
		subCamera = GameObject.Find("SubCamera").transform.position;
		temp = new GameObject[(int)maxNum];

		//grovePos = grove.transform.position;
		//armPos = arm.transform.position;
		for (n = 0; n < maxNum; n++) {
			//Vector3 minPos = (grovePos - armPos) / (maxNum + 1.0f);
			//Vector3 thisPos = minPos * n;
			temp[n] = (GameObject)Instantiate (springPrefab);
			//temp[n].transform.localScale = new Vector3( 0.1f,0.1f,0.1f);//springsize, springsize, springsize);
			//temp[n].transform.position = thisPos + armPos;
			//temp[n].transform.LookAt( grovePos );
			//transform.Rotate(new Vector3( -90, 0, 0));
		}
	}

	// Update is called once per frame
	void Update () {

		grovePos = grove.transform.position;
		armPos = arm.transform.position;
		for (n = 0; n < maxNum; n++) {
			Vector3 minPos = (grovePos - armPos) / (maxNum + 1.0f);
			Vector3 thisPos = minPos * n;
			temp[n].transform.localScale = new Vector3( springsize, springsize, springsize);
			temp[n].transform.position = thisPos + armPos;//+ subCamera;
			temp[n].transform.LookAt( grovePos );
			temp[n].transform.Rotate(new Vector3(0.0f, 90.0f, 90.0f));
		}
	}
}
