using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpaceShipData spaceShipData;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public Transform spawnShipPoint;
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
    private bool CalculateShotColDown()
    {
        if (Time.time > nextShoot)
        {
            canShoot = true;
        }
        return canShoot;
    }

    private void Movement()
    {
        movement = Input.GetAxisRaw(inputHorizontal);
        rigidbody2D.velocity = new Vector2(movement * spaceShipData.movementVelocity, rigidbody2D.velocity.y);
    }
    private void Shoot()
    {
        canShoot = false;
        nextShoot = Time.time + spaceShipData.shootCoolDown;
        bulletPrefab.transform.localScale = transform.localScale;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
    public void TakeDamage()
    {
        transform.position = spawnShipPoint.position;
        currentLifes--;
        GameManager.instance.SetLifes(currentLifes);
    }
}
