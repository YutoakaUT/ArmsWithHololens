using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject _target;
    void Update()
    {
            this.transform.LookAt(_target.transform.position);
    }
}
