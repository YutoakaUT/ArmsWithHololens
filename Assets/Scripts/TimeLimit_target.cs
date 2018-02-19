using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeLimit_target: MonoBehaviour
{
    public static int timeflag;
    public static int gameflag;
	public Text gameOverText; //ゲームオーバーの文字
    public float limit;

    // Use this for initialization
    void Start()
    {
        gameflag = 0;
		gameOverText.enabled = false;
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
			//ゲームオーバーの文字を表示
			gameOverText.enabled = true;

			//画面をクリックすると
			if (Input.GetKeyDown (KeyCode.Q)) {
            SceneManager.LoadSceneAsync("Start"); //ページ遷移
            gameflag = 0; //フラグを初期化
			}
        }
    }
}