using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    public AmmoType ammoType;
    public int amount;

    public override void PickedUp()
    {
        base.PickedUp();
        GetPlayer().GetComponent<AmmoInventory>().AddAmmoOfType(amount, ammoType);
    }
}
