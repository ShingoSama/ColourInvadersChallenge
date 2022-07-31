using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPlaying;
    //Game Objects to play
    public GameObject levelShields;
    public List<GameObject> shields;
    public GameObject Enemies;
    public GameObject spaceShip;
    public GameObject starsMovement;
    public GameObject panelGameInfo;
    public GameObject panelGameOver;
    public GameObject textNewHighScore;
    public Text finalScore;
    public Text finalHighScore;
    public Button buttonMainMenu;
    //TextUIScore
    public Text textScore;
    private int score;
    //TextUIScore
    public Text textLifes;
    //TextUIScore
    public Text textHighScore;
    public int highScore;
    private bool isNewHighScore;
    public enum gameState
    {
        Menu,
        Playing,
        EndGame
    }
    public gameState gameStatus;

    private void Awake()
    {
        SetGameStatus(false);
        gameStatus = gameState.Menu;
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
    public void PlayGame()
    {
        SetGameStatus(true);
        score = 0;
        isNewHighScore = false;
        SetScore(score);
        Enemies.SetActive(true);
        EnemiesSpawner.instance.ResetEnemies();
        foreach (GameObject shield in shields)
        {
            shield.SetActive(true);
            shield.GetComponent<Shield>().ResetShield();
        }
        gameStatus = gameState.Playing;
    }
    public void EndGame()
    {
        textNewHighScore.SetActive(isNewHighScore);
        SetGameStatus(false);
        finalScore.text = score.ToString("D10");
        finalHighScore.text = highScore.ToString("D10");
        panelGameOver.SetActive(true);
        gameStatus = gameState.EndGame;
        levelShields.SetActive(false);
        Enemies.SetActive(false);
        spaceShip.SetActive(false);
        panelGameInfo.SetActive(false);
        starsMovement.SetActive(false);
        ButtonMainMenuSelected();
    }
    public void ButtonMainMenuSelected()
    {
        buttonMainMenu.Select();
    }
    public void ExitGame()
    {
        Application.Quit();
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
            isNewHighScore = true;
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
    public void SetGameStatus(bool gameStatus)
    {
        isPlaying = gameStatus;
    }
}
