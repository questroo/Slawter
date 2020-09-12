using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        PickedUp();
        Destroy(gameObject);
    }
    public virtual void PickedUp()
    {
        Debug.Log("Picked up the item");
        GetComponentInParent<ItemSpawner>().StartRespawnTimer();
        FindObjectOfType<PopupUIManager>().DisplayEventText("Picked up " + gameObject.name);
    }
    public GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
