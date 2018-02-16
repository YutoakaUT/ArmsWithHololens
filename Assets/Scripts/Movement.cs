using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;
	private Rigidbody rb;
	private float movementInputValue;
	private float turnInputValue;

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
		movement.y*=0;
		rb.MovePosition(rb.position + movement.normalized/3);
	}

	// 左右移動のメソッド
	void Turn(){
		movementInputValue = Input.GetAxis("Horizontal");
		Vector3 movement = transform.right * movementInputValue * moveSpeed * Time.deltaTime;
		movement.y*=0;
		rb.MovePosition(rb.position + movement.normalized/3);
	}
	
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.velocity+=new Vector3(0,10,0);
	}
}