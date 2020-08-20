using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static bool hasWaveStarted;
    public static int numberOfEnemies;

    private static List<Enemy> enemies;

    public void FindEnemies()
    {
        enemies = FindObjectsOfType<Enemy>().ToList();
    }

    public void RemoveEnemyFromList(Enemy me)
    {
        enemies.Remove(me);
        if(enemies.Count <= 0)
        {
            hasWaveStarted = false;
            FindObjectOfType<SpawnerManager>().SetEnemyCount();
        }
    }
}
