using UnityEngine;
using System.Collections;

public class Rotatemuzzle : MonoBehaviour
{
    public float x = 30;
    public float y = 30;
    public float z = 30;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(-1*x, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1*y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(x, 0, 0));
        }
    }
}