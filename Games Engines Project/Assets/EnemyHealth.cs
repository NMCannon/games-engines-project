using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public EnemyHealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
