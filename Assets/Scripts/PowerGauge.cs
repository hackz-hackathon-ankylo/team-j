using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PowerGauge : MonoBehaviour
{

    [SerializeField]private Color color1, color2, color3, color4, color5; // カラーの種類を4種類用意する
    [SerializeField]private float maxPG = 100; // 最大パワーゲージ数字を100とする
    [SerializeField]private Image Powergauge; // パワーゲージの画像をいれる
    [SerializeField]private float PG_ratio; // パワーゲージ100%を1としたときのゲージ割合
    [SerializeField]JoyconPositionInformation JoyPosInfo;
    [SerializeField]ActionPoint actionPoint;
    public float nowPG = 0; // 今のパワーゲージの値を初期値を0とする

    void Update()
    {
        nowPG = actionPoint.AddPowerGauge(nowPG);

        PG_ratio = nowPG / maxPG; // PG_ratioの計算式

        if (PG_ratio > 0.75f)
        {
            Powergauge.color = Color.Lerp(color2, color1, (PG_ratio - 0.75f) * 4f);
        }
        else if(PG_ratio > 0.50f)
        {
            Powergauge.color = Color.Lerp(color3, color2, (PG_ratio - 0.50f) * 4f);
        }
        else if(PG_ratio > 0.25f)
        {
            Powergauge.color = Color.Lerp(color4, color3, (PG_ratio - 0.25f) * 4f);            
        }
        else
        {
            Powergauge.color = Color.Lerp(color5, color4, PG_ratio * 4f);
        }

        Powergauge.fillAmount = PG_ratio;
    }
}