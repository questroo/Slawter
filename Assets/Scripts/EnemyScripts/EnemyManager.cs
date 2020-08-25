using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static bool hasWaveStarted;

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
        FindObjectOfType<EnemyRemainingUI>().UpdateText(enemies.Count);
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
        FindObjectOfType<EnemyRemainingUI>().UpdateText(enemies.Count);
    }
}
