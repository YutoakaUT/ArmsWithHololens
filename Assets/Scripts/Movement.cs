using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;
	private Rigidbody rb;
	private float movementInputValue;
	private float turnInputValue;
	public bool Debug = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		Move();
		Turn();
		Jump();
	}

	// 前後移動のメソッド
	void Move(){
		movementInputValue = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}

	// 左右移動のメソッド
	void Turn(){
		if (Debug == false) {
			turnInputValue = Input.GetAxis ("Horizontal");
			float turn = turnInputValue * turnSpeed * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler (0, turn, 0);
			rb.MoveRotation (rb.rotation * turnRotation);
		} else {
			movementInputValue = Input.GetAxis ("Horizontal");
			Vector3 movement = transform.right * movementInputValue * moveSpeed * Time.deltaTime;
			rb.MovePosition (rb.position + movement);
		}
	}
	
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.velocity+=new Vector3(0,10,0);
	}
}