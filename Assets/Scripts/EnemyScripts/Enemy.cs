using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public bool showDebugUI = true;
    public HP hp;
    private float currentHP;
    public bool playerInSight = false;
    public float walkMoveSpeed = 3.5f;
    public float runMoveSpeed = 6.0f;
    public EnemyAIRanges ranges;
    public EnemyDamage enemyDamage;
    private Slider healthSlider;
    public LineRenderer bulletTrail;
    public float attackRate = 0.5f;
    public Transform shootFromPosition;
    private bool isDead = false;
    public Wall currentlyOccupiedWall = null;
    public Transform Target { get; private set; }

    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        healthSlider = GetComponentInChildren<Slider>();
        currentHP = hp.maxHP;
        healthSlider.maxValue = hp.maxHP;
        healthSlider.value = currentHP;
        healthSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        var playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        healthSlider.gameObject.transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
    }
    public abstract void InitializeStateMachine();

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = currentHP;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public float GetHP()
    {
        return currentHP;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
        if (Target)
        {
            InvokeRepeating("Attack", attackRate, attackRate);
        }
        else
        {
            CancelInvoke("Attack");
        }
    }

    public void Attack()
    {
        RaycastHit rayHit;

        if (Physics.Raycast(shootFromPosition.position, GetRandomDirectionToTargetFromShootPosition(), out rayHit, ranges.attackRange))
        {
            var player = rayHit.collider.GetComponent<Health>();
            var nexus = rayHit.collider.GetComponent<NexusHealth>();

            if (player)
            {
                RegisterToDamageIndicator();
                player.TakeDamage(enemyDamage.damage);
            }
            if (nexus)
            {
                nexus.TakeDamage(enemyDamage.damage);
            }
            SpawnBulletTrail(rayHit.point);
        }
    }

    private Vector3 GetRandomDirectionToTargetFromShootPosition()
    {
        var randomDir = ExtensionMethods.GetRandomOffsetedVectorFromPoint(Target.position, 0.6f);
        return randomDir - shootFromPosition.position;
    }

    private void SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, shootFromPosition.position, Quaternion.identity);

        LineRenderer lineRenderer = bulletTrailEffect.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.SetPosition(0, shootFromPosition.position);
        lineRenderer.SetPosition(1, hitPoint);

        Destroy(bulletTrailEffect, 0.1f);
    }
    private void Die()
    {
        isDead = true;
        healthSlider.gameObject.SetActive(false);
        FindObjectOfType<EnemyManager>().RemoveEnemyFromList(this);
    }
    public bool CheckIsDead()
    {
        return isDead;
    }
    void RegisterToDamageIndicator()
    {
        if (!DamageIndicatorSystem.CheckIfObjectInSight(this.transform))
        {
            DamageIndicatorSystem.CreateIndicator(this.transform);
        }
    }
}
