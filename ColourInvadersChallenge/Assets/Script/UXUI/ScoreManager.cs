using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int enemiesKilled;
    private int scoreCalculated;
    private EnemyData.alienColours currentAlienColor;
    private void Awake()
    {
        enemiesKilled = 0;
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SumEnemyKilled(EnemyData.alienColours alienColour)
    {
        if (enemiesKilled == 0)
        {
            enemiesKilled++;
            currentAlienColor = alienColour;
        }
        else if (currentAlienColor == alienColour)
        {
            enemiesKilled++;
        }
        else
        {
            enemiesKilled = 0;
            enemiesKilled++;
            currentAlienColor = alienColour;
        }
    }
    //Reset the counter for the enemies hit combo
    private void ResetCounter()
    {
        enemiesKilled = 0;
        scoreCalculated = 0;
        currentAlienColor = EnemyData.alienColours.none;
    }
    public void ShowScore()
    {
        int firstValue = 0;
        int secontValue = 1;

        //fibonacci
        for (int i = 0; i < enemiesKilled; i++)
        {
            //Store a value en a temp variable.
            int temp = firstValue;

            //value 1 it's convert in value 2.
            firstValue = secontValue;

            //Sum both values.
            secontValue = temp + firstValue;
        }

        scoreCalculated = enemiesKilled * secontValue * 10;
        GameManager.instance.SumScore(scoreCalculated);
        ResetCounter();
    }
}
