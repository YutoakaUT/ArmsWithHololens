using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glovetranslation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = 
			new Vector3 ( transform.localScale.x, transform.localScale.y, transform.localScale.z * -1 );
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
