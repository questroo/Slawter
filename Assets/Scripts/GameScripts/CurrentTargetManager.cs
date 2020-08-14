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
    public void AssignTarget(Enemy newTarget)
    {
        currentTarget = newTarget;
        if(currentTarget.CheckIsDead())
        {
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
