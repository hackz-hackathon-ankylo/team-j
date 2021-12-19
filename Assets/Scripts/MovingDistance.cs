using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingDistance : MonoBehaviour
{
    [SerializeField]Text scoreText;
    ScoreText score;
    private int movingDistance = 0;
    private int deltaPoint = 1;
    void Start(){
        score = scoreText.GetComponent<ScoreText>();
    }
    public void AddMovingDistance()
    {
        movingDistance += deltaPoint;
        score.Score = movingDistance;
    }

}
