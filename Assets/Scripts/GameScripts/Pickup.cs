using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PickedUp();
        Destroy(gameObject);
    }
    public virtual void PickedUp()
    {
        Debug.Log("Picked up the item");
    }
}
