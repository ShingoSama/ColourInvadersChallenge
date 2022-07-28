using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpaceShipData spaceShipData;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public string inputHorizontal;
    private Rigidbody2D rigidbody2D;
    private float movement;
    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        GameManager.instance.SetLifes(spaceShipData.maxHealth);
        GameManager.instance.SetScore(spaceShipData.currentScore);
        GameManager.instance.SetHighScore(spaceShipData.higthScore);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetGameStatus())
        {
            Movement();
            if (Input.GetButtonDown("Jump"))
            {
                Shoot();
            }
        }
    }
    private void Movement()
    {
        movement = Input.GetAxisRaw(inputHorizontal);
        rigidbody2D.velocity = new Vector2(movement * spaceShipData.movementVelocity, rigidbody2D.velocity.y);
    }
    private void Shoot()
    {
        bulletPrefab.transform.localScale = transform.localScale;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
