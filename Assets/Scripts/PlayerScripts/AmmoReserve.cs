using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    RifleAmmo,
    ShotgunAmmo,
    HandgunAmmo
}

public class AmmoReserve : MonoBehaviour
{
    public int currentRifleAmmo = 120;
    public int currentShotgunAmmo = 24;
    public int currentHandgunAmmo = 48;
}
