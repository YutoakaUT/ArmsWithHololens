using UnityEngine;
using System.Collections;
public class Shooting : MonoBehaviour
{
    public GameObject punch;
    public Transform muzzle;

    public float speed = 1000;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject punches = GameObject.Instantiate(punch)as GameObject;

            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            punches.GetComponent<Rigidbody>().AddForce(force);
            punches.transform.position = muzzle.position;
        }
    }
}