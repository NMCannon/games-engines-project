using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyHealthBar healthBar;
    public GenerateEnemies enemyManager;

    [SerializeField] ScoreScript scoreScript;


    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Lower health
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        // If enemy is dead
        if (currentHealth <= 0)
        {
            // Play death audio
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            // Destroy the enemy object
            Destroy(gameObject);
            //yield return new WaitForSeconds(1);
            // Add a point to player's score
            scoreScript.AddPoint();
            // Record death with enemy manager class
            enemyManager.EnemyDeath();
            Debug.Log("ENEMY COUNT: " + enemyManager.enemyCount);
        }
    }
}
