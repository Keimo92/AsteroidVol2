using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public static Scoring instance;

    public Text scoreText;
    public Text highScoreText;
    public int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance= this;
    }


    private void Start()
    {

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "HighScore: " + highScore.ToString(); 
                                
    }

    public void AddPoint(int pointValue)
    {
        score = score + pointValue;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
        PlayerPrefs.SetInt("HighScore", score);
    }
}




