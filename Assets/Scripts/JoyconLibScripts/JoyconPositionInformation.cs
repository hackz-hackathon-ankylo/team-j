using System.Collections;

using System.Collections.Generic;

using UnityEngine;




public class JoyconPositionInformation : MonoBehaviour

{

    [SerializeField]JoyconInformation joyconInfo;
    [SerializeField]ActionPoint actionPoint;
    [SerializeField]MovingDistance movingDistance;
    [SerializeField]PlayerMovement playerMovement;

    private bool isArmIntermediate = false;
    private bool isArmHighest = false;
    private bool isLegIntermediate = false;
    private bool isLegHighest = false;

    void Update()
    {
        if(Time.timeScale != 0){
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
                actionPoint.AddActionPoint(0.5f);
                isArmIntermediate = true;
            }

            //左側のJoy-Con（足のJoy-Con）が中間点の時の処理
            if(joyconInfo.isIntermediatePositionL && !isLegIntermediate)
            {
                movingDistance.AddMovingDistance();
                playerMovement.AddPlayerVelocity(2);
                isLegIntermediate = true;
            }

            //右側のJoy-Con（腕のJoy-Con）が最高点の時の処理
            if(joyconInfo.isHighestPositionR && !isArmHighest)
            {
                actionPoint.AddActionPoint(1f);
                isArmHighest = true;
            }

            //左側のJoy-Con（足のJoy-Con）が最高点の時の処理
            if(joyconInfo.isHighestPositionL && !isLegHighest)
            {
                playerMovement.AddPlayerVelocity(2);
                isLegHighest =true;
            }
        }
    }

}