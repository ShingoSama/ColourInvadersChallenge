using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Values of colour
    public List<EnemyData> enemiesData;
    private EnemyData enemyData;
    //Variables to die
    private int currentHealth;
    private bool isDead;
    //Variables of Attack
    public GameObject bulletPrefab;
    public GameObject explosion;
    public Transform shootPoint;
    public LayerMask detectPlayer;
    private bool canShoot;
    private float nextShoot;
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
    private Vector3 initialPosition;
    public LayerMask wallLayer;
    public float speedMultiplier;
    private void Awake()
    {
        initialPosition = transform.position;
        InitializeAlien();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesSpawner.instance.moveRight)
        {
            rigidbody2D.velocity = new Vector2(Vector2.right.x * (enemyData.movementVelocity + speedMultiplier), rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(Vector2.left.x * (enemyData.movementVelocity + speedMultiplier), rigidbody2D.velocity.y);
        }
        if (WallDetection())
        {
            Flip();
        }
        RaycastHit2D hit2DEnemy = Physics2D.Raycast(bottomPoint.position, Vector2.down, 2f, enemyData.layerMask);
        if (hit2DEnemy.transform == null)
        {
                RaycastHit2D hit2D = Physics2D.Raycast(bottomPoint.position, Vector2.down, 10f, detectPlayer);
            if (hit2D && CalculateShotColDown())
            {
                if (Time.time > nextShoot)
                {
                    Shoot();
                }


            }
        }
    }
    //Add speed multiplier to the alien
    public void AddSpeed(float multiplier)
    {
        speedMultiplier = speedMultiplier + multiplier;
    }
    //Calculate if the allen can shoot
    private bool CalculateShotColDown()
    {
        if (Time.time > nextShoot)
        {
            canShoot = true;
        }
        return canShoot;
    }
    //Decrease Health and search another alien close
    public void DecreaseHealth()
    {
        currentHealth--;
        Debug.Log("Enemy Health" + currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Instantiate(explosion, transform.position, transform.rotation);
            EnemiesSpawner.instance.DecreaseEnemyCounter();
            ScoreManager.instance.SumEnemyKilled(enemyData.colour);
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
    public void InitializeAlien()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        enemyData = enemiesData[Random.Range(0, 5)];
        spriteRenderer.sprite = enemyData.sprite;
        transform.position = initialPosition;
        animator.runtimeAnimatorController = enemyData.animator;
        currentHealth = enemyData.maxHealth;
        canShoot = true;
        nextShoot = 0;
        isDead = false;
        speedMultiplier = 0f;
    }
    private bool WallDetection()
    {
        if (EnemiesSpawner.instance.moveRight)
        {
            return Physics2D.Raycast(transform.position, Vector2.right, 0.5f, wallLayer);
        }
        else
        {
            return Physics2D.Raycast(transform.position, Vector2.left, 0.5f, wallLayer);;
        }
    }
    private void Flip()
    {
        EnemiesSpawner.instance.moveRight = !EnemiesSpawner.instance.moveRight;
        EnemiesSpawner.instance.transform.Translate(Vector3.down * 0.15f);
    }
    //Call a the bullet prefab and init cool down to the next shot
    private void Shoot()
    {
        canShoot = false;
        nextShoot = Time.time + enemyData.shootCoolDown;
        bulletPrefab.transform.localScale = transform.localScale;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
    //If collide whit a DefenderShield, destroy the alien and sum a hit to DefenderShield
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DefenderShield"))
        {
            collision.gameObject.GetComponent<Shield>().DecreaseHealth();
            currentHealth--;
            isDead = true;
            Instantiate(explosion, transform.position, transform.rotation);
            EnemiesSpawner.instance.DecreaseEnemyCounter();
            gameObject.SetActive(false);
        }
    }
}
