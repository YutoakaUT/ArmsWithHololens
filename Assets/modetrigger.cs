using UnityEngine;

public class modetrigger : MonoBehaviour 
{
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			GetComponent<Animator> ().SetTrigger ("MouseOn");
		}
	}
}