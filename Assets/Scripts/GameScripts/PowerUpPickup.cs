using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : Pickup
{
    public float duration = 10.0f;

    public override void PickedUp()
    {
        base.PickedUp();

        GetPlayer().GetComponentInChildren<Gun>().TurnOnUnlimitedAmmo(duration);
    }
}
