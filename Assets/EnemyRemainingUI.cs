using UnityEngine;
using TMPro;

public class EnemyRemainingUI : MonoBehaviour
{
    public TextMeshProUGUI EnemiesRemainingText;

    private void Start()
    {
        EnemiesRemainingText.text = "Enemies Remaining: 0";
    }

    public void UpdateText(int enemiesRemaining)
    {
        EnemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
    }
}
