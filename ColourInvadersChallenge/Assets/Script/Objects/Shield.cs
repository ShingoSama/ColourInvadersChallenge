using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject explosion;
    private Animator anim;
    private int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 4;
        currentHealth = maxHealth;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Decrease health an change the animation
    public void DecreaseHealth()
    {
        currentHealth--;
        anim.SetInteger("Hits", currentHealth);
        if (currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
    //Reset shield health to the new game
    public void ResetShield()
    {
        currentHealth = maxHealth;
    }
}
