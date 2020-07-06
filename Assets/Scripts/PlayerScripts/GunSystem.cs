using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    // Gun stats
    public float damage, timeBetweenShooting, range, reloadTime, timeBetweenShots;
    //public float spread;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    private int bulletsLeft, bulletsShot;

    // Bools
    private bool shooting, readyToShoot, reloading;

    // References
    public Camera fpsCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public TextMeshProUGUI text;

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
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
            Reload();
        }

        // Shoot
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        // Raycast
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out rayHit, range, whatIsEnemy))
        {
            if(rayHit.collider.transform.parent.CompareTag("Enemy"))
            {
                Debug.Log("EnemyFound");
                rayHit.collider.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
            }
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

        if(bulletsShot > 0 && bulletsLeft > 0)
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
        bulletsLeft = magazineSize;
        reloading = false;
    }
}