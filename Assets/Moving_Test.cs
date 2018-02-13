using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Test : MonoBehaviour
{
    public float speed = 3.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.M))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
}