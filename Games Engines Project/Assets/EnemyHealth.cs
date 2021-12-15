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
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //yield return new WaitForSeconds(1);
            scoreScript.AddPoint();
            enemyManager.EnemyDeath();
            Debug.Log("ENEMY COUNT: " + enemyManager.enemyCount);
        }
    }
}
