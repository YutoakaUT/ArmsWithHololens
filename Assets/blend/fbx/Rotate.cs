using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	void Update () {
		gameObject.transform.Rotate(
			Input.GetAxis("Vertical"),
			Input.GetAxis("Horizontal"),
			0
			, Space.World
		);
			gameObject.transform.Rotate(0, 1f, 0, Space.World);
		
	}
}