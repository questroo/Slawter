using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public float maxHealth = 255.0f;
    private float currentHealth;
    public PlayerHealthUI playerHealthUI;

    private void Awake()
    {
        currentHealth = maxHealth;
        playerHealthUI.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            Die();
        }
        playerHealthUI.SetHealth(currentHealth);
    }

    private void Die()
    {
        OnPlayerDeath?.Invoke();
        Debug.Log("you have died.");
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetPlayerMaxHealth()
    {
        return maxHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth = currentHealth + healAmount > maxHealth ? maxHealth : currentHealth + healAmount;
        playerHealthUI.SetHealth(currentHealth);
    }
}
