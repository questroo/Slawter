using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Pistol,
    Shotgun,
    Rifle,
    Sniper,
    GrenadeLauncher
}
public class AmmoInventory : MonoBehaviour
{
    private int currentPistolAmmo = 24;
    private int currentShotgunAmmo = 8;
    private int currentRifleAmmo = 40;
    private int currentSniperAmmo = 7;
    private int currentGrenadeLauncherAmmo = 0;

    public int CurrentPistolAmmo
    {
        get
        {
            return currentPistolAmmo;
        }
        set
        {
            currentPistolAmmo = value;
        }
    }
    public int CurrentShotgunAmmo
    {
        get
        {
            return currentShotgunAmmo;
        }
        set
        {
            currentShotgunAmmo = value;
        }
    }
    public int CurrentRifleAmmo
    {
        get
        {
            return currentRifleAmmo;
        }
        set
        {
            currentRifleAmmo = value;
        }
    }
    public int CurrentSniperAmmo
    {
        get
        {
            return currentSniperAmmo;
        }
        set
        {
            currentSniperAmmo = value;
        }
    }
    public int CurrentGrenadeLauncherAmmo
    {
        get
        {
            return currentGrenadeLauncherAmmo;
        }
        set
        {
            currentGrenadeLauncherAmmo = value;
        }
    }

    public void AddAmmoOfType(int amount, AmmoType ammoType)
    {
        switch (ammoType)
        {
            case AmmoType.Pistol:
                CurrentPistolAmmo += amount;
                break;
            case AmmoType.Shotgun:
                CurrentShotgunAmmo += amount;
                break;
            case AmmoType.Rifle:
                CurrentRifleAmmo += amount;
                break;
            case AmmoType.Sniper:
                CurrentSniperAmmo += amount;
                break;
            default:
                break;
        }
    }
    public int AskForAmmoOfType(int amount, AmmoType ammoType)
    {
        switch (ammoType)
        {
            case AmmoType.Pistol:
                if (amount <= CurrentPistolAmmo)
                {
                    CurrentPistolAmmo = CurrentPistolAmmo - amount < 0 ? 0 : CurrentPistolAmmo - amount;
                    return amount;
                }
                else
                {
                    int remainder = CurrentPistolAmmo;
                    CurrentPistolAmmo = 0;
                    return remainder;
                }
            case AmmoType.Shotgun:
                if (amount <= CurrentShotgunAmmo)
                {
                    CurrentShotgunAmmo = CurrentShotgunAmmo - amount < 0 ? 0 : CurrentShotgunAmmo - amount;
                    return amount;
                }
                else
                {
                    int remainder = CurrentShotgunAmmo;
                    CurrentShotgunAmmo = 0;
                    return remainder;
                }
            case AmmoType.Rifle:
                if (amount <= CurrentRifleAmmo)
                {
                    CurrentRifleAmmo = CurrentRifleAmmo - amount < 0 ? 0 : CurrentRifleAmmo - amount;
                    return amount;
                }
                else
                {
                    int remainder = CurrentRifleAmmo;
                    CurrentRifleAmmo = 0;
                    return remainder;
                }
            case AmmoType.Sniper:
                if (amount <= CurrentSniperAmmo)
                {
                    CurrentSniperAmmo = CurrentSniperAmmo - amount < 0 ? 0 : CurrentSniperAmmo - amount;
                    return amount;
                }
                else
                {
                    int remainder = CurrentSniperAmmo;
                    CurrentSniperAmmo = 0;
                    return remainder;
                }
            default:
                return 0;
        }
    }
    public int GetCurrentAmmoAmount(AmmoType ammoType)
    {
        switch (ammoType)
        {
            case AmmoType.Pistol:
                return CurrentPistolAmmo;
            case AmmoType.Shotgun:
                return CurrentShotgunAmmo;
            case AmmoType.Rifle:
                return CurrentRifleAmmo;
            case AmmoType.Sniper:
                return CurrentSniperAmmo;
            default:
                return 0;
        }
    }
}
