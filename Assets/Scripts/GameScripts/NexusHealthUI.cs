using UnityEngine;
using UnityEngine.UI;

public class NexusHealthUI : MonoBehaviour
{
    private Slider healthSlider;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        Vector3 targetLookAt = GameObject.FindGameObjectWithTag("Player").transform.position;
        var targetLookAtModified = new Vector3(targetLookAt.x, transform.position.y, targetLookAt.z);
        transform.parent.gameObject.transform.LookAt(targetLookAtModified);
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