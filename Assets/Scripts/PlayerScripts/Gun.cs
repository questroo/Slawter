using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    // Gun stats
    public float damage, timeBetweenShooting, range, reloadTime, timeBetweenShots;
    public float spread;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    private int bulletsLeft, bulletsShot;
    public AmmoType ammoType;

    // Bools
    private bool shooting, readyToShoot, reloading;

    // References
    public Camera fpsCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public TextMeshProUGUI text;
    private AmmoInventory ammoInventory;

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;

    private void Awake()
    {
        ammoInventory = GetComponentInParent<AmmoInventory>();
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + ammoInventory.GetCurrentAmmoAmount(ammoType));
    }
    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            if (ammoInventory.GetCurrentAmmoAmount(ammoType) > 0)
            {
                Reload();
            }
            else
            {
                Debug.Log("You have no ammo left");
            }
        }

        // Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        // Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCamera.transform.forward + new Vector3(x, y, 0);

        // Raycast
        if (Physics.Raycast(fpsCamera.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log("EnemyFound");
            rayHit.collider.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
        }

        // Graphics
        var bulletImpactInstance = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        var muzzleFlashInstance = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        muzzleFlashInstance.transform.parent = gameObject.transform;

        Destroy(bulletImpactInstance, 0.6f);
        Destroy(muzzleFlashInstance, 0.16f);

        --bulletsLeft;
        --bulletsShot;
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        int bulletsNeeded = magazineSize - bulletsLeft;
        int bulletsRecieved = 0;
        if (ammoInventory.GetCurrentAmmoAmount(ammoType) > 0)
        {
            bulletsRecieved = ammoInventory.AskForAmmoOfType(bulletsNeeded, ammoType);
        }
        bulletsLeft += bulletsRecieved;
        reloading = false;
    }
}