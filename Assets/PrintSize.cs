using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(gameObject.GetComponent<Renderer>().bounds.size.x);
		print(gameObject.GetComponent<Renderer>().bounds.size.y);
		print(gameObject.GetComponent<Renderer>().bounds.size.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
