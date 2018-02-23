using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveRotation : MonoBehaviour {
	public float wSpeed = 10;
	public float sSpeed = 7;
	public float adRotate = 100;


	float maxRotate = 25;//回転角の最大値//
	float tmpRotate = 0;//現在の回転角//
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.H))
		{
			if (tmpRotate <= maxRotate) {
				this.transform.Rotate (new Vector3 (adRotate, 0, 0) * Time.deltaTime);
				tmpRotate += (adRotate * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.Y))
		{
			if (tmpRotate >= -maxRotate) {
				this.transform.Rotate (new Vector3 (-adRotate, 0, 0) * Time.deltaTime);
				tmpRotate -= (adRotate * Time.deltaTime);
			}			
		}
	}
}