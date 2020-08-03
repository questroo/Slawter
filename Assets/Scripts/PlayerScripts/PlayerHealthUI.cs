using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    
    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    public void SetHealth(float health)
    {
        healthText.text = health.ToString();
    }
}
