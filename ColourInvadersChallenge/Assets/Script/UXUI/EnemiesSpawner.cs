using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner instance;
    public List<GameObject> enemiesSpawn;
    public Transform spawnPoint;
    public bool moveRight;
    private int maxEnemies;
    private int currentEnemies;
    private void Awake()
    {
        maxEnemies = enemiesSpawn.Count;
        currentEnemies = maxEnemies;
        moveRight = true;
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
        if (currentEnemies == 0)
        {
            ResetEnemies();
        }
    }
    //Reset the enemies to continue playing, reset her position and speed
    public void ResetEnemies()
    {
        transform.position = spawnPoint.position;
        foreach (GameObject enemySpawn in enemiesSpawn)
        {
            enemySpawn.SetActive(true);
            enemySpawn.GetComponent<EnemyController>().InitializeAlien();
        }
        currentEnemies = maxEnemies;
    }
    //Substract enemies counter and add multipler speed
    public void DecreaseEnemyCounter()
    {
        currentEnemies--;
        foreach (GameObject enemySpawn in enemiesSpawn)
        {
            enemySpawn.GetComponent<EnemyController>().AddSpeed(0.1f);
        }
    }
}
