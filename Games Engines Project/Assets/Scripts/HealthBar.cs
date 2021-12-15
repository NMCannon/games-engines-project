using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;

    private void Start()
    {
        // Get player's health variable
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        // Get the health bar slider
        healthBar = GetComponent<Slider>();
        // Set max value on slider to player's max health
        healthBar.maxValue = playerHealth.maxHealth;
        // Set the value to max (start of game)
        healthBar.value = playerHealth.maxHealth;
    }

    // Update health bar
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}