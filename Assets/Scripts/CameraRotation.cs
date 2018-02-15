using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float fMouseX = Input.GetAxis("Mouse X");
        float fMouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, fMouseX * 10, Space.World);
        transform.Rotate(Vector3.right,-fMouseY * 10, Space.Self);
	}
}