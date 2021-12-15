using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = enemyHealth.maxHealth;
        healthBar.value = enemyHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}