using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public WaveEnemyAmount waveEnemyAmount;
    public int timeBetweenRounds = 10;
    private Spawner[] spawners;
    public int startingWave = 0;
    private int currentWave;
    private int numberToSpawn = 0;
    private PopupUIManager popupUIManager;

    private void Start()
    {
        popupUIManager = FindObjectOfType<PopupUIManager>();
        currentWave = startingWave;
        spawners = FindObjectsOfType<Spawner>();
        SetEnemyCount();
    }

    public void SetEnemyCount()
    {
        ++currentWave;
        switch (currentWave)
        {
            case 1:
                numberToSpawn = waveEnemyAmount.enemyCountWave1;
                break;
            case 2:
                numberToSpawn = waveEnemyAmount.enemyCountWave2;
                break;
            case 3:
                numberToSpawn = waveEnemyAmount.enemyCountWave3;
                break;
            case 4:
                numberToSpawn = waveEnemyAmount.enemyCountWave4;
                break;
            case 5:
                numberToSpawn = waveEnemyAmount.enemyCountWave5;
                break;
            case 6:
                numberToSpawn = waveEnemyAmount.enemyCountWave6;
                break;
            case 7:
                numberToSpawn = waveEnemyAmount.enemyCountWave7;
                break;
            case 8:
                numberToSpawn = waveEnemyAmount.enemyCountWave8;
                break;
            case 9:
                numberToSpawn = waveEnemyAmount.enemyCountWave9;
                break;
            default:
                break;
        }
        StartCoroutine(popupUIManager.CountdownForRound(timeBetweenRounds));
        Invoke("SendSpawnCommand", timeBetweenRounds);
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
        popupUIManager.DisplayEventText("Wave " + currentWave + " has started.");
    }
}
