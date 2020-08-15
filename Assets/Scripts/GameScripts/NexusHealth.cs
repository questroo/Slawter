using System;
using UnityEngine;

public class NexusHealth : MonoBehaviour
{
    public delegate void NexusDeath();
    public static event NexusDeath OnNexusDeath;

    public float maxHealth = 255.0f;
    private float currentHealth;
    public NexusHealthUI nexusHealthUI;

    private void Start()
    {
        currentHealth = maxHealth;
        nexusHealthUI.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(30.0f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            Die();
        }
        nexusHealthUI.SetHealth(currentHealth);
    }

    private void Die()
    {
        OnNexusDeath?.Invoke();
        Debug.Log("Nexus has been destroyed.");
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
