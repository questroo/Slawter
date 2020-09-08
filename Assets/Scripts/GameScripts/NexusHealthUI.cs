using UnityEngine;
using UnityEngine.UI;

public class NexusHealthUI : MonoBehaviour
{
    private Slider healthSlider;
    [SerializeField] private bool inViewOfCamera;
    public GameObject nexus;
    public Image nexusImage;
    public float borderMargin = 20.0f;

    private void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        Vector3 targetLookAt = GameObject.FindGameObjectWithTag("Player").transform.position;
        var targetLookAtModified = new Vector3(targetLookAt.x, transform.position.y, targetLookAt.z);
        transform.parent.gameObject.transform.LookAt(targetLookAtModified);
        var viewportPoint = Camera.main.WorldToViewportPoint(nexus.transform.position);
        // This object is within the cameras view.
        inViewOfCamera = viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1;
        if (!inViewOfCamera)
        {
            nexusImage.enabled = true;
            if (viewportPoint.z <= 0)
            {
                // If target is behind camera then snap position to the top of the screen.
                viewportPoint.y -= 1;
            }
            var screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);
            screenPoint.x = (Mathf.Clamp(screenPoint.x, borderMargin, Screen.width - borderMargin));
            screenPoint.y = (Mathf.Clamp(screenPoint.y, borderMargin, Screen.height - borderMargin));
            nexusImage.transform.position = screenPoint;
        }
        else
        {
            nexusImage.enabled = false;
        }
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