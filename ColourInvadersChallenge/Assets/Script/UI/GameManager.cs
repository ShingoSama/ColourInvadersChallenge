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
    //TextUIScore
    public Text textLifes;
    //TextUIScore
    public Text textHighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    internal void SetScore(int score)
    {
        textScore.text = score.ToString("D10");
    }

    internal void SetHighScore(int highScore)
    {
        textHighScore.text = highScore.ToString("D10");
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    internal void SetLifes(int totalLife)
    {
        textLifes.text = totalLife.ToString();
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
