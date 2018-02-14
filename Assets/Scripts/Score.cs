using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // スコアを表示する
    Text scoreText;
    // スコア
    public static int score;


    void Start()
    {
		Initialize();
		scoreText=GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        // スコア・ハイスコアを表示する
		scoreText.text = "Score:"+score.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
		score = 0;
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
		score = score + point;
    }
}