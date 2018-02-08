using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;// ←new!

public class Scene_move : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Juvenail_ver1");
    }

}