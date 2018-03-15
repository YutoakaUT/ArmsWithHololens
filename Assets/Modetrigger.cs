
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Modetrigger : MonoBehaviour, IFocusable
{
    void Update()
    {
		if (Input.GetMouseButtonDown(0)) {
			GetComponent<Animator> ().SetBool ("idle", true);
		} else if(Input.GetMouseButtonUp(0)) {
			GetComponent<Animator> ().SetBool ("idle", false);
		}
    }
	public void OnFocusEnter()
	{
		GetComponent<Animator> ().SetBool ("idle", true);
		//GetComponent<Animator>().SetTrigger("MouseOn");
		// throw new System.NotImplementedException();
	}

	public void OnFocusExit()
	{
		GetComponent<Animator> ().SetBool ("idle", false);
		// throw new System.NotImplementedException();
	}

}