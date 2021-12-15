using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public HealthBar healthBar;

    public GameOverScreen GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            GameOverScreen.Setup();
        }
    }
}
