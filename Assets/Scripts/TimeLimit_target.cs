using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeLimit_target: MonoBehaviour
{
    public static int timeflag;
    public static int gameflag;
    //public static float countTime;
    public float limit = 180;
    // Use this for initialization
    void Start()
    {
        //timeflag = 0;
        //countTime = 0;
        gameflag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameflag == 0)
        {
            if (limit > 0)
            {
                limit -= Time.deltaTime; //スタートしてからの秒数を格納
            }
            else if (limit <= 0)
            {
                limit = 0;  //limitを0に調整
                gameflag = 1;
            }
  
            GetComponent<Text>().text = limit.ToString("F2"); //小数2桁にして表示
 
        }
        if (gameflag == 1) {
            Target_making.targetz.Clear();
            SceneManager.LoadSceneAsync("Start"); //ページ遷移
            gameflag = 0; //フラグを初期化
        }
    }
}