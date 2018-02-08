using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour
{

    private Animator SkelMesh_Bodyguard_01;
    // Use this for initialization
    void Start()
    {
        SkelMesh_Bodyguard_01 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.1f;
            SkelMesh_Bodyguard_01.SetBool("is_running", true);
        }
        else
        {
            SkelMesh_Bodyguard_01.SetBool("is_running", false);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
        }
    }
}