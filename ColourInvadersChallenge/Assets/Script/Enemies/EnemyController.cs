using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<EnemyData> enemiesData;
    public GameObject bulletPrefab;
    private EnemyData enemyData;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        enemyData = enemiesData[Random.Range(0, 5)];
        spriteRenderer.sprite = enemyData.sprite;
        animator.runtimeAnimatorController = enemyData.animator;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecreaseHealth()
    {
        enemyData.currentHealth--;
        if (enemyData.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
