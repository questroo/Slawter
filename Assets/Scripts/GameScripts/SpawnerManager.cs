using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public WaveEnemyAmount waveEnemyAmount;
    private Spawner[] spawners;
    private int currentWaveEnemyCount = 1;

    private void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        SetEnemyCount();
    }

    public void SetEnemyCount()
    {
        switch (currentWaveEnemyCount)
        {
            case 1:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave1;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 2:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave2;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 3:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave3;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 4:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave4;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 5:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave5;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 6:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave6;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 7:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave7;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 8:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave8;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 9:
                EnemyManager.numberOfEnemies = currentWaveEnemyCount = waveEnemyAmount.enemyCountWave9;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            default:
                break;
        }
        ++currentWaveEnemyCount;
    }

    private void SendSpawnCommand()
    {
        for (int enemy = 0; enemy < currentWaveEnemyCount; ++enemy)
        {
            int index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();
        }
        foreach (Spawner spawner in spawners)
        {
            spawner.Spawn();
        }
        EnemyManager.hasWaveStarted = true;
    }
}
