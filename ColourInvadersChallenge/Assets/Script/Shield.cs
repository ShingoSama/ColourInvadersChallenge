using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecreaseHealth()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
