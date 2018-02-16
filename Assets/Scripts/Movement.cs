using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed;
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
		Assault();
	}

	// 前後移動のメソッド
	void Move(){
		movementInputValue = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * movementInputValue * Time.deltaTime;
		movement.y*=0;
		rb.MovePosition(rb.position + movement.normalized * moveSpeed / 10);
	}

	// 左右移動のメソッド
	void Turn(){
		movementInputValue = Input.GetAxis("Horizontal");
		Vector3 movement = transform.right * movementInputValue * Time.deltaTime;
		movement.y*=0;
		rb.MovePosition(rb.position + movement.normalized * moveSpeed / 10);
	}
	
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.velocity+=new Vector3(0,10,0);
	}
	
	void Assault()
	{
		if (Input.GetKey(KeyCode.Q)&&Input.GetKey(KeyCode.E))
			rb.velocity = transform.forward.normalized*100;
	}
}