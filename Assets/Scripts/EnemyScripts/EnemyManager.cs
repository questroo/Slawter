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

    //private void Update()
    //{
    //    if (enemies != null)
    //    {
    //        Debug.Log("There are " + enemies.Count + "enemies");
    //    }
    //}

    public void FindEnemies()
    {
        var allEnemies = FindObjectsOfType<Enemy>().ToList();
        enemies = allEnemies.Where(enemy => !deadEnemies.Any(dead => dead == enemy)).ToList();
        enemiesRemainingText.text = enemies.Count.ToString();
    }

    public void RemoveEnemyFromList(Enemy me)
    {
        enemies.Remove(me);
        deadEnemies.Add(me);
        if (enemies.Count <= 0)
        {
            hasWaveStarted = false;
            FindObjectOfType<SpawnerManager>().SetEnemyCount();
        }
        enemiesRemainingText.text = enemies.Count.ToString();
    }
}
