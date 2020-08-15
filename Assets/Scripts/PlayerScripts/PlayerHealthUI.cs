using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    
    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        healthText.text = 250.ToString();
    }

    public void SetHealth(float health)
    {
        healthText.text = health.ToString();
    }
}
