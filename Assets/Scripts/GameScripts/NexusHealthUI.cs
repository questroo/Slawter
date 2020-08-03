using UnityEngine;
using UnityEngine.UI;

public class NexusHealthUI : MonoBehaviour
{
    private Slider healthSlider;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}