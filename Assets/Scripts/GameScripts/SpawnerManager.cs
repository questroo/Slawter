using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private Spawner[] spawners;

    private void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        InvokeRepeating("SendSpawnCommand", 3.0f, 20.0f);
    }

    private void SendSpawnCommand()
    {
        foreach(Spawner spawner in spawners)
        {
            spawner.Spawn();
        }
    }
}
