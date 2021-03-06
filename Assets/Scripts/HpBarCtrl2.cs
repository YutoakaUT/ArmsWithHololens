﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBarCtrl2 : MonoBehaviour
{
    public static int damage2;
    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider_AI").GetComponent<Slider>();
    }

    float _hp = 100;
    void Update()
    {
        // HP上昇
        _hp -= damage2;
        if (_hp < _slider.minValue)
        {
            // 最大を超えたら0に戻す
            _hp = _slider.maxValue;
        }
        damage2 = 0;
        // HPゲージに値を設定
        _slider.value = _hp;
    }

}

