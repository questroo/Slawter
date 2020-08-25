using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public WaveEnemyAmount waveEnemyAmount;
    private Spawner[] spawners;
    public int startingWave = 1;
    private int currentWave;
    private int numberToSpawn = 0;

    private void Start()
    {
        currentWave = startingWave;
        spawners = FindObjectsOfType<Spawner>();
        SetEnemyCount();
    }

    //private void Update()
    //{
    //    print("Current wave " + currentWave);
    //}

    public void SetEnemyCount()
    {
        switch (currentWave)
        {
            case 1:
                numberToSpawn = waveEnemyAmount.enemyCountWave1;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 2:
                numberToSpawn = waveEnemyAmount.enemyCountWave2;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 3:
                numberToSpawn = waveEnemyAmount.enemyCountWave3;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 4:
                numberToSpawn = waveEnemyAmount.enemyCountWave4;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 5:
                numberToSpawn = waveEnemyAmount.enemyCountWave5;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 6:
                numberToSpawn = waveEnemyAmount.enemyCountWave6;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 7:
                numberToSpawn = waveEnemyAmount.enemyCountWave7;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 8:
                numberToSpawn = waveEnemyAmount.enemyCountWave8;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            case 9:
                numberToSpawn = waveEnemyAmount.enemyCountWave9;
                Invoke("SendSpawnCommand", 3.0f);
                break;
            default:
                break;
        }
        ++currentWave;
    }

    private void SendSpawnCommand()
    {
        for (int enemy = 0; enemy < numberToSpawn; ++enemy)
        {
            int index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();
        }
        FindObjectOfType<EnemyManager>().FindEnemies();
        EnemyManager.hasWaveStarted = true;
    }
}
