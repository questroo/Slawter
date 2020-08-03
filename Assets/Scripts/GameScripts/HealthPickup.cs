using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float healthRecoveredAmount = 50.0f;
    public override void OnTriggerEnter(Collider other)
    {
        if(GetPlayer().GetComponent<Health>().GetCurrentHealth() <
            GetPlayer().GetComponent<Health>().GetPlayerMaxHealth())
        {
            base.OnTriggerEnter(other);
        }
    }

    public override void PickedUp()
    {
        base.PickedUp();
        GetPlayer().GetComponent<Health>().Heal(healthRecoveredAmount);
    }
}
