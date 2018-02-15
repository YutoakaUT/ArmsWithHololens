using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
	// Use this for initialization

	float maxRotate = 25;//回転角の最大値//
	float tmpRotate = 0;//現在の回転角//
	public float adRotate = 100;

	public bool Debug = false;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		if (Debug == false) {
			if (Input.GetKey (KeyCode.G)) {
				if (tmpRotate <= maxRotate) {
					this.transform.Rotate (new Vector3 (adRotate, 0, 0) * Time.deltaTime);
					tmpRotate += (adRotate * Time.deltaTime);
				}
			}
			if (Input.GetKey (KeyCode.T)) {
				if (tmpRotate >= -maxRotate) {
					this.transform.Rotate (new Vector3 (-adRotate, 0, 0) * Time.deltaTime);
					tmpRotate -= (adRotate * Time.deltaTime);
				}			
			}
		} else {
			float fMouseX = Input.GetAxis ("Mouse X");
			float fMouseY = Input.GetAxis ("Mouse Y");
			transform.Rotate (Vector3.up, fMouseX * 10, Space.World);
			transform.Rotate (Vector3.right, -fMouseY * 10, Space.Self);
		}
	}
}