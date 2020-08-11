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
    public WeaponType weaponType;
    private bool spendBullets = true;
    // Bools
    private bool shooting, readyToShoot, reloading;

    // References
    public Camera fpsCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public TextMeshProUGUI text;
    public LineRenderer bulletTrail;
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

        // Play the animation for shooting
        GetComponentInChildren<Animator>().SetTrigger("Shoot");

        // Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCamera.transform.forward + new Vector3(x, y, 0);

        // Raycast
        if (Physics.Raycast(fpsCamera.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Enemy enemy = rayHit.collider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
                DamagePopup.Create(rayHit.point, damage);
            }
            SpawnBulletTrail(rayHit.point);
        }

        // Graphics
        var bulletImpactInstance = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        var muzzleFlashInstance = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


        muzzleFlashInstance.transform.parent = gameObject.transform;

        Destroy(bulletImpactInstance, 0.6f);
        Destroy(muzzleFlashInstance, 0.1f);

        if (spendBullets)
        {
            --bulletsLeft;
            --bulletsShot;
        }
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
        GetComponentInChildren<Animator>().SetBool("Reloading", true);
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
        GetComponentInChildren<Animator>().SetBool("Reloading", false);
    }

    private void SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, attackPoint.position, Quaternion.identity);

        LineRenderer lineRenderer = bulletTrailEffect.GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, attackPoint.position);
        lineRenderer.SetPosition(1, hitPoint);

        Destroy(bulletTrailEffect, 0.1f);
    }

    public void TurnOnUnlimitedAmmo(float duration)
    {
        spendBullets = false;

        Invoke("TurnOffUnlimitedAmmo", duration);
    }

    public void TurnOffUnlimitedAmmo()
    {
        spendBullets = true;
    }
}