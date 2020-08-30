using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    private GameControls controls;

    // Gun stats
    public float damage, timeBetweenShooting, range, reloadTime, timeBetweenShots;
    public float spread;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    private int bulletsLeft, bulletsShot;
    public float zoomInFOV;
    public bool canADS;
    public AmmoType ammoType;
    public WeaponType weaponType;
    private bool spendBullets = true;
    private bool isADSing = false;
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
        if (controls == null)
        {
            controls = new GameControls();
        }
        ammoInventory = GetComponentInParent<AmmoInventory>();
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Start()
    {
        if (allowButtonHold)
        {
            controls.Player.Shoot.performed += ctx => shooting = true;
            controls.Player.Shoot.canceled += ctx => shooting = false;
        }
        else
        {
            controls.Player.Shoot.performed += ctx => shooting = true;
        }

        if (canADS)
        {
            controls.Player.AimDownSight.performed += ctx => isADSing = !isADSing;
        }

        controls.Player.Reload.performed += ctx => Reload();
    }

    private void Update()
    {
        MyInput();
        text.SetText(bulletsLeft + " / " + ammoInventory.GetCurrentAmmoAmount(ammoType));
        if (!allowButtonHold)
        {
            shooting = false;
        }
    }
    private void MyInput()
    {
        if (isADSing)
        {
            Camera.main.fieldOfView = zoomInFOV;
        }
        else
        {
            Camera.main.fieldOfView = 60.0f;
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
        LineRenderer lr = SpawnBulletTrail(direction);
        if (Physics.Raycast(fpsCamera.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Enemy enemy = rayHit.collider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
                CurrentTargetManager.Instance.AssignTarget(enemy);
                DamagePopup.Create(rayHit.point, damage);
            }
            lr.SetPosition(1, rayHit.point);
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
        if (ammoInventory.GetCurrentAmmoAmount(ammoType) > 0 && bulletsLeft < magazineSize)
        {
            reloading = true;
            GetComponentInChildren<Animator>().SetBool("Reloading", true);
            Invoke("ReloadFinished", reloadTime);
        }
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

    private LineRenderer SpawnBulletTrail(Vector3 direction)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, attackPoint.position, Quaternion.identity);

        LineRenderer lineRenderer = bulletTrailEffect.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.SetPosition(0, attackPoint.position);
        lineRenderer.SetPosition(1, attackPoint.position + direction * 5000.0f);

        Destroy(bulletTrailEffect, 0.02f);
        return lineRenderer;
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
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}