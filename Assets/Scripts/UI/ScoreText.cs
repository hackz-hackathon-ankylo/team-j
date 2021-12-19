using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int Score{
        
        get{
            return Convert.ToInt32(scoreText);
        }
        set{
            String text = value.ToString();
            scoreText.text = $"{text}m";
        }
    }
}
