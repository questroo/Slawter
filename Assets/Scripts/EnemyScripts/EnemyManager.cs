using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
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
            if (FindObjectOfType<SpawnerManager>().GetCurrentWave() >= 9)
            {
                PostRoundSummaryManager.Instance.Victory();
            }
            else
            {
                PostRoundSummaryManager.Instance.OpenSummary();
            }
            RoundDataManager.Instance.ResetData();
        }
        enemiesRemainingText.text = enemies.Count.ToString();
    }

    private void CleanUpDeadEnemies()
    {
        foreach (Enemy enemy in deadEnemies)
        {
            Destroy(enemy.gameObject);
        }
        deadEnemies.Clear();
    }

    private void OnEnable()
    {
        PostRoundSummaryManager.OnRoundStarted += CleanUpDeadEnemies;
    }

    private void OnDisable()
    {
        PostRoundSummaryManager.OnRoundStarted -= CleanUpDeadEnemies;
    }
}
