using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 255.0f;
    public float currentHealth;
    public HealthBarUI healthBarUI;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarUI.SetMaxHealth(maxHealth);
        healthBarUI.SetHealth(currentHealth);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(15.0f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBarUI.SetHealth(currentHealth);
        if(currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("you have died.");
    }
}
