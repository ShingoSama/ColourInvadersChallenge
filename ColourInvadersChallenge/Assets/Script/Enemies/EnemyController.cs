using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Values of colour
    public List<EnemyData> enemiesData;
    private EnemyData enemyData;
    //Variables to die
    public GameObject explotion;
    private int currentHealth;
    private bool isDead;
    //Variables of Attack
    public GameObject bulletPrefab;
    public Transform shootPoint;
    //Variables to destroy Right Top Left or Bottom Aliens
    public Transform topPoint;
    public Transform leftPoint;
    public Transform bottomPoint;
    public Transform rightPoint;
    //Variables to animate the alien
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //Variables to move the alien
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        enemyData = enemiesData[Random.Range(0, 5)];
        spriteRenderer.sprite = enemyData.sprite;
        animator.runtimeAnimatorController = enemyData.animator;
        currentHealth = enemyData.maxHealth;
        isDead = false;
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
        currentHealth--;
        Debug.Log("Enemy Health" + currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            //explotion.transform.localScale = rightPoint.localScale;
            //explotion.GetComponent<Shoots>().colour = enemyData.colour;
            //explotion.GetComponent<Shoots>().direction = Vector2.right;
            //Instantiate(explotion, rightPoint.position, rightPoint.rotation);
            //explotion.transform.localScale = leftPoint.localScale;
            //explotion.GetComponent<Shoots>().colour = enemyData.colour;
            //explotion.GetComponent<Shoots>().direction = Vector2.left;
            //Instantiate(explotion, leftPoint.position, leftPoint.rotation);
            //explotion.transform.localScale = topPoint.localScale;
            //explotion.GetComponent<Shoots>().colour = enemyData.colour;
            //explotion.GetComponent<Shoots>().direction = Vector2.up;
            //Instantiate(explotion, topPoint.position, topPoint.rotation);
            //explotion.transform.localScale = bottomPoint.localScale;
            //explotion.GetComponent<Shoots>().colour = enemyData.colour;
            //explotion.GetComponent<Shoots>().direction = Vector2.down;
            //Instantiate(explotion, bottomPoint.position, bottomPoint.rotation);
            DetectEnemy(rightPoint.position, Vector2.right);
            DetectEnemy(leftPoint.position, Vector2.left);
            DetectEnemy(topPoint.position, Vector2.up);
            DetectEnemy(bottomPoint.position, Vector2.down);
            gameObject.SetActive(false);
        }
    }
    private void DetectEnemy(Vector3 position, Vector2 direction)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(position, direction, 2f, enemyData.layerMask);
        DetectColorAndContinue(hit2D);
    }
    private void DetectColorAndContinue(RaycastHit2D hit2D)
    {
        if (hit2D != null)
        {
            if (hit2D.transform != null)
            {
                if (hit2D.transform.GetComponent<EnemyController>() != null)
                {
                    if (hit2D.transform.GetComponent<EnemyController>().enemyData.colour == enemyData.colour)
                    {
                        Debug.Log("Color" + enemyData.colour);
                        hit2D.transform.GetComponent<EnemyController>().DecreaseHealth();
                    }
                }
            }
        }
    }
}
