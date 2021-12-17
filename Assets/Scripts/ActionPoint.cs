using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アクションポイントを管理するクラス
/// </summary>
public class ActionPoint : MonoBehaviour
{
    const float MaxActionPoint = 100f;

    const float MinActionPoint = 0f;

    [System.NonSerialized]public float actionPoint = 0;

    /// <summary>
    /// アクションポイントを一追加する関数
    /// </summary>
    public void AddActionPoint()
    {
        actionPoint++;
    }

    /// <summary>
    /// パワーゲージの増減をする関数
    /// </summary>
    public float ChangePowerGauge(float x)
    {
        if(x < actionPoint)
        {
            x += 0.05f;
        }
        else if(x > actionPoint)
        {
            x = actionPoint;
        }
        return x;
    }

    /// <summary>
    /// 障害物の耐久度を減らす関数
    /// </summary>
    public float ReduceObjectDurability(float x)
    {
        x -= actionPoint;
        return x;
    }

    /// <summary>
    /// アクションポイントを減らす関数
    /// </summary>
    public void ReduceActionPoint(float x)
    {
        actionPoint -= x;
    }
    void Update()
    {
        if(MaxActionPoint < actionPoint)actionPoint = MaxActionPoint;

        if(actionPoint < MinActionPoint)actionPoint = MinActionPoint;
    }
}
