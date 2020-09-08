using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;
    public Image arrowImage;

    public IEnumerator ShowEnemyAttackDirectionIndicator(Enemy enemy)
    {
        Vector3 targetLookAt = GameObject.FindGameObjectWithTag("Player").transform.position;
        var targetLookAtModified = new Vector3(targetLookAt.x, transform.position.y, targetLookAt.z);
        transform.parent.gameObject.transform.LookAt(targetLookAtModified);
        var viewportPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);
        // This object is within the cameras view.
        arrowImage.enabled = true;
        if (viewportPoint.z <= 0)
        {
            // If target is behind camera then snap position to the top of the screen.
            viewportPoint.y -= 1;
        }
        var screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);
        screenPoint.x = (Mathf.Clamp(screenPoint.x, (Screen.width/2) - 20.0f, (Screen.width / 2) + 20.0f));
        screenPoint.y = (Mathf.Clamp(screenPoint.y, (Screen.height/2) - 20.0f, (Screen.height / 2) + 20.0f));
        arrowImage.transform.position = screenPoint;

        //yield return new wait
    }

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
