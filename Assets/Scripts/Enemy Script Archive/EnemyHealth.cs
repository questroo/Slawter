using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(15.0f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            // A: Calls a "Die" state, Destroys Game Object
            Destroy(gameObject);

        }
        Debug.Log("Health: " + currentHealth);
    }
}
