using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPlaying;

    //TextUIScore
    public Text textScore;
    private int score;
    //TextUIScore
    public Text textLifes;
    //TextUIScore
    public Text textHighScore;
    private int highScore;

    private void Awake()
    {
        score = 0;
        highScore = 0;
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }
    public void SetLifes(int totalLife)
    {
        textLifes.text = totalLife.ToString();
    }
    public void SetHighScore(int newHighScore)
    {
        highScore = newHighScore;
        textHighScore.text = highScore.ToString("D10");
    }
    public void SetScore(int score)
    {
        textScore.text = score.ToString("D10");
    }
    public void SumScore(int scoreToSum)
    {
        score = scoreToSum + score;
        SetScore(score);
        if (score > highScore)
        {
            SetHighScore(score);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetGameStatus()
    {
        return isPlaying;
    }
}
