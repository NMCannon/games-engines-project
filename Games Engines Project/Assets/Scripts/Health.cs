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
        // Play audio when hit
        FindObjectOfType<AudioManager>().Play("PlayerHurt");

        // Lower health
        currentHealth -= amount;

        // Set health bar to current health
        healthBar.SetHealth(currentHealth);

        // If health lower than 0 game over
        if(currentHealth <= 0)
        {
            // Play audio when player dies
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            // Show game over ui
            GameOverScreen.Setup();
        }
    }
}
