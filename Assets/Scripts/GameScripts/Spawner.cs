﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnableEnemies;

    public void Spawn()
    {
        int randomIndex = Random.Range(0, spawnableEnemies.Length);
        Instantiate(spawnableEnemies[randomIndex], transform);
    }
}
