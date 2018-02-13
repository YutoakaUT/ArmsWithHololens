using UnityEngine;
using System.Collections;

public class Reflection : MonoBehaviour
{
    public Transform originalObject;
    public Transform reflectedObject;
    void Update()
    {
        reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);
    }
}