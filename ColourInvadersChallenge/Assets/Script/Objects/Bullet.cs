using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float shootSpeed;
    public bool isTopDirection;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isTopDirection)
        {
            rigidbody2D.AddForce(Vector2.up * shootSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rigidbody2D.AddForce(Vector2.down * shootSpeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision" + collision.gameObject.layer.ToString());
        switch (collision.gameObject.tag)
        {
            case "LebelLimit":
                Debug.Log("Colision" + "LebelLimit");
                Destroy(gameObject);
                break;
            case "DefenderShield":
                Debug.Log("Colision" + "DefenderShield");
                collision.gameObject.GetComponent<Shield>().DecreaseHealth();
                Destroy(gameObject);
                break;
            case "Enemy":
                Debug.Log("Colision" + "Enemy");
                if (collision.gameObject.GetComponent<EnemyController>())
                {
                    collision.gameObject.GetComponent<EnemyController>().DecreaseHealth();
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
