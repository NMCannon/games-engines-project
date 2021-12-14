using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyHealthBar healthBar;


    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        GameObject enemyManager = GameObject.Find("EnemyManager");
        GenerateEnemies generateEnemies = enemyManager.GetComponent<GenerateEnemies>();

        if (currentHealth <= 0)
        {
            generateEnemies.EnemyDeath();
            Debug.Log("ENEMY COUNT: " + generateEnemies.enemyCount);
            Destroy(gameObject);
        }
    }
}
