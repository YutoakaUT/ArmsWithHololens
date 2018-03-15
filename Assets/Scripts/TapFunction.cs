using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapFunction : MonoBehaviour, IInputClickHandler
{
    public string scenename;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // Increase the scale of the object just as a response.
        //gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;
        SceneManager.LoadScene(scenename);
        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }
}
