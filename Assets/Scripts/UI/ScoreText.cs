using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public int Score{
        set{
        scoreText.text = value.ToString();
        }
    }
}
