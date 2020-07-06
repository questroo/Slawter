using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    int weaponSelected = 3;

    [SerializeField]
    GameObject rifle;   // 1
    [SerializeField]
    GameObject sniper;  // 2
    [SerializeField]
    GameObject handgun; // 3

    private void Start()
    {
        SwapWeapon(weaponSelected);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponSelected != 1)
            {
                SwapWeapon(1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
            }
        }
    }

    void SwapWeapon(int weaponType)
    {
        switch (weaponType)
        {
            case 1:
                rifle.SetActive(true);
                sniper.SetActive(false);
                handgun.SetActive(false);
                break;
            case 2:
                rifle.SetActive(false);
                sniper.SetActive(true);
                handgun.SetActive(false);
                break;
            case 3:
                rifle.SetActive(false);
                sniper.SetActive(false);
                handgun.SetActive(true);
                break;
            default:
                break;
        }
        weaponSelected = weaponType;
    }
}
