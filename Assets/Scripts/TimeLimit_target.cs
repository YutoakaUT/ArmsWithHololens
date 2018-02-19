using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeLimit_target: MonoBehaviour
{
    public static int timeflag;
	int gameflag = 0;
	public GameObject resultPrefab; //　終了した時に表示するUI
	private GameObject instanceResultUI;　//　resultUIのインスタンス
    public float limit;

    // Use this for initialization
    void Start()
    {
   
	}

    // Update is called once per frame
    void Update()
    {
        if (gameflag == 0)
        {
			if (Time.timeScale != 1.0F) {
				Time.timeScale = 1.0F;
			}

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

			if (instanceResultUI == null) {
				instanceResultUI = (GameObject)Instantiate (resultPrefab);
			}
			Time.timeScale = 0f; //ゲームをフリーズ
			//Qを押すと
			if (Input.GetKeyDown (KeyCode.Q)) {
				Target_making.targetz.Clear();
				Destroy (instanceResultUI);
				Time.timeScale = 1f; //フリーズ解除
          	  gameflag = 0; //フラグを初期化
				SceneManager.LoadSceneAsync("Start"); //ページ遷移
			}
        }
    }
}