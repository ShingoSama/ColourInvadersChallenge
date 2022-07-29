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
    private void ResetCounter()
    {
        enemiesKilled = 0;
        scoreCalculated = 0;
        currentAlienColor = EnemyData.alienColours.none;
    }
    public void ShowScore()
    {
        int v1 = 0;
        int v2 = 1;

        for (int i = 0; i < enemiesKilled; i++)
        {
            //Almacenamos el valor v1 en una variable temporal para no perderlo.
            int temp = v1;

            //El valor 1 se convierte en el valor 2.
            v1 = v2;

            //Sumamos los valores.
            v2 = temp + v1;
        }

        scoreCalculated = enemiesKilled * v2 * 10;
        GameManager.instance.SumScore(scoreCalculated);
        ResetCounter();
    }
}
