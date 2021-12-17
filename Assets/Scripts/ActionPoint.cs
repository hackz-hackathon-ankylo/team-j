using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoint : MonoBehaviour
{
    const float MaxActionPoint = 100f;

    const float MinActionPoint = 0f;

    [System.NonSerialized]public float actionPoint = 0;

    
    public void AddActionPoint()
    {
        actionPoint++;
    }
    public float AddPowerGauge(float x)
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
    public float ReduceObjectDurability(float x)
    {
        x -= actionPoint;
        return x;
    }
    public void ReduceActionPoint(float x)
    {
        actionPoint -= x;
    }
    void Update()
    {
        if(MaxActionPoint < actionPoint)actionPoint = MaxActionPoint;

        if(actionPoint < MinActionPoint)actionPoint = MinActionPoint;
        Debug.Log(actionPoint);
    }
}
