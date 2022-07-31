using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpaceShipData spaceShipData;
    public GameObject bulletPrefab;
    public GameObject explosion;
    public Transform shootPoint;
    public Transform spawnShipPoint;
    public AudioSource audioShoot;
    public string inputHorizontal;
    private Rigidbody2D rigidbody2D;
    public int currentLifes;
    private float movement;
    private bool canShoot;
    private float nextShoot;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        nextShoot = 0f;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        currentLifes = spaceShipData.maxHealth;
        GameManager.instance.SetLifes(spaceShipData.maxHealth);
        GameManager.instance.SetScore(0);
        GameManager.instance.SetHighScore(spaceShipData.higthScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetGameStatus() && currentLifes > 0)
        {
            Movement();
            if (Input.GetButtonDown("Jump") && CalculateShotColDown())
            {
                Shoot();
            }
        }
    }
    //Calculate if can soot
    private bool CalculateShotColDown()
    {
        if (Time.time > nextShoot)
        {
            canShoot = true;
        }
        return canShoot;
    }
    //Player movement
    private void Movement()
    {
        movement = Input.GetAxisRaw(inputHorizontal);
        rigidbody2D.velocity = new Vector2(movement * spaceShipData.movementVelocity, rigidbody2D.velocity.y);
    }
    //Call a the bullet prefab and init cool down to the next shot
    private void Shoot()
    {
        canShoot = false;
        nextShoot = Time.time + spaceShipData.shootCoolDown;
        bulletPrefab.transform.localScale = transform.localScale;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        audioShoot.Play();
    }
    //Take damage for the player and reset her position
    //if the lifes is equal to 0 call the end game
    public void TakeDamage()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        transform.position = spawnShipPoint.position;
        currentLifes--;
        if (currentLifes > 0)
        {
            GameManager.instance.SetLifes(currentLifes);
        }
        else
        {
            currentLifes = spaceShipData.maxHealth;
            spaceShipData.higthScore = GameManager.instance.highScore;
            GameManager.instance.EndGame();
            GameManager.instance.SetHighScore(spaceShipData.higthScore);
        }
    }
}
