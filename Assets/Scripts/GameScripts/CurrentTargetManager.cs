using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentTargetManager : Singleton<CurrentTargetManager>
{
    private Enemy currentTarget;
    public GameObject currentTargetCanvas;
    public TextMeshProUGUI currentTargetNameText;
    public Slider currentTargetHealthSlider;

    private void Start()
    {
        currentTargetCanvas.SetActive(false);
    }
    private void Update()
    {
        if (currentTarget)
        {
            var playerPos = FindObjectOfType<PlayerMovement>().transform;
            transform.LookAt(new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z));
            transform.parent = playerPos;
        }
    }
    public void AssignTarget(Enemy newTarget)
    {
        var newPosition = newTarget.transform.position;
        newPosition.y += 4.0f;
        transform.position = newPosition;
        currentTarget = newTarget;
        if (currentTarget.CheckIsDead())
        {
            currentTarget = null;
            currentTargetCanvas.SetActive(false);
            return;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        currentTargetCanvas.SetActive(true);
        currentTargetNameText.text = currentTarget.gameObject.name;
        currentTargetHealthSlider.maxValue = currentTarget.hp.maxHP;
        currentTargetHealthSlider.value = currentTarget.GetHP();
    }
}
