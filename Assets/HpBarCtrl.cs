using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour
{
    public static int damage;
    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _hp = 100;
    void Update()
    {
        // HP上昇
        _hp -=damage;
        if (_hp < _slider.minValue)
        {
            // 最大を超えたら0に戻す
            _hp = _slider.maxValue;
        }
        damage = 0;
        // HPゲージに値を設定
        _slider.value = _hp;
    }

}

