using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public float spawnDelay = 10.0f;

    private void Start()
    {
        int index = Random.Range(0, items.Length);
        Instantiate(items[index], transform);
    }
    public void StartRespawnTimer()
    {
        StartCoroutine("WaitForRespawn");
    }
    public IEnumerator WaitForRespawn()
    {
        float time = 0.0f;
        while (time < spawnDelay)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Spawn();
    }

    private void Spawn()
    {
        int index = Random.Range(0, items.Length);
        Instantiate(items[index], transform);
        FindObjectOfType<PopupUIManager>().DisplayEventText(items[index].gameObject.name + " has spawned!");
    }
}
