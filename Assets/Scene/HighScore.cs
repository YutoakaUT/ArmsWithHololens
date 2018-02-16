using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour
{

    // スコアを表示する
    Text highScoreText;
    // スコア
    public static int highScore;
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー

    void Start()
    { 
        //保存しておいたハイスコアをキーで呼び出し取得
        //保存されていなければ0が返る
        highScore =PlayerPrefs.GetInt(key, 0);
        highScoreText=GameObject.Find("HighScore").GetComponent<Text>();
        //ハイスコアを表示
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    void Update()
    {
        if (Score.score > highScore)
        {
            //ハイスコア更新
            highScore = Score.score;
            //ハイスコアを保存
            PlayerPrefs.SetInt(key, highScore);
            //ハイスコアを表示
            highScoreText.text = "HighScore: " + highScore.ToString();
        }
    }

}