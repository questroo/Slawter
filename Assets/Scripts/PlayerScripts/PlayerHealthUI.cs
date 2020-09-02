using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;

    public void InitializeHealthBar(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = healthSlider.maxValue;
    }
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
