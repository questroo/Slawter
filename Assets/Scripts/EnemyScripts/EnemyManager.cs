using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static bool hasWaveStarted;
    public Text enemiesRemainingText;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private List<Enemy> deadEnemies;


    public void FindEnemies()
    {
        var allEnemies = FindObjectsOfType<Enemy>().ToList();
        enemies = allEnemies.Where(enemy => !deadEnemies.Any(dead => dead == enemy)).ToList();

        enemiesRemainingText.text = enemies.Count.ToString();
    }

    public void RemoveEnemyFromList(Enemy me)
    {
        RoundDataManager.Instance.kills++;
        enemies.Remove(me);
        deadEnemies.Add(me);
        if (enemies.Count <= 0)
        {
            PostRoundSummaryManager.Instance.OpenSummary();
            RoundDataManager.Instance.ResetData();
            hasWaveStarted = false;
        }
        enemiesRemainingText.text = enemies.Count.ToString();
    }
}
