using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private GameControls controls;
    int weaponSelected = 3;

    public GameObject rifle;   // 1
    public GameObject sniper;  // 2
    public GameObject handgun; // 3

    private void Awake()
    {
        if (controls == null)
        {
            controls = new GameControls();
        }
    }
    private void Start()
    {
        SwapWeapon(weaponSelected);
        controls.Player.SwapWeapon1.performed += ctx => SwapWeapon(1);
        controls.Player.SwapWeapon2.performed += ctx => SwapWeapon(2);
        controls.Player.SwapWeapon3.performed += ctx => SwapWeapon(3);
    }

    void SwapWeapon(int weaponSlot)
    {
        switch (weaponSlot)
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
        weaponSelected = weaponSlot;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
