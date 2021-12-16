using System.Collections;

using System.Collections.Generic;

using UnityEngine;




public class JoyconPositionInformation : MonoBehaviour

{

    const float MaxActionPoint = 100f;

    const float MinActionPoint = 0f;

    [SerializeField]private JoyconInformation joyconInfo;

    public float actionPoint = 0;

    private float movingDistance = 0;
    private bool isArmIntermediate = false;
    private bool isArmHighest = false;
    private bool isLegIntermediate = false;
    private bool isLegHighest = false;
    void Update()
    {
        //右側のJoy-Con（腕のJoy-Con）が最低点の時の処理
        if(joyconInfo.isLowestPositionR)
        {
            isArmIntermediate = false;
            isArmHighest = false;
        }

        //左側のJoy-Con（足のJoy-Con）が最低点の時の処理
        if(joyconInfo.isLowestPositionL)
        {
            isLegIntermediate = false;
            isLegHighest = false;
        }

        //右側のJoy-Con（腕のJoy-Con）が中間点の時の処理
        if(joyconInfo.isIntermediatePositionR && !isArmIntermediate)
        {
            actionPoint++;
            isArmIntermediate = true;
        }

        //左側のJoy-Con（足のJoy-Con）が中間点の時の処理
        if(joyconInfo.isIntermediatePositionL && !isLegIntermediate)
        {
            movingDistance++;
            isLegIntermediate = true;
        }

        //右側のJoy-Con（腕のJoy-Con）が最高点の時の処理
        if(joyconInfo.isHighestPositionR && !isArmHighest)
        {
            actionPoint++;
            isArmHighest = true;
        }

        //左側のJoy-Con（足のJoy-Con）が最高点の時の処理
        if(joyconInfo.isHighestPositionL && !isLegHighest)
        {
            movingDistance++;
            isLegHighest =true;
        }

        if(MaxActionPoint < actionPoint)actionPoint = MaxActionPoint;

        if(actionPoint < MinActionPoint)actionPoint = MinActionPoint;

    }

}