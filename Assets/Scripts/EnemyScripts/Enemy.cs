using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public HP hp;
    private float currentHP;
    public EnemyAIRanges ranges;
    public EnemyDamage enemyDamage;
    public LineRenderer bulletTrail;
    public float attackRate = 0.5f;
    public Transform shootFromPosition;
    private bool isDead = false;

    //[SerializeField] private LayerMask layerMask;

    public Transform Target { get; private set; }

    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        currentHP = hp.maxHP;
    }

    public abstract void InitializeStateMachine();

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
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
        if(Target)
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

            if(player)
            {
                player.TakeDamage(enemyDamage.damage);
            }
            if(nexus)
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

        lineRenderer.SetPosition(0, shootFromPosition.position);
        lineRenderer.SetPosition(1, hitPoint);

        Destroy(bulletTrailEffect, 0.1f);
    }
    private void Die()
    {
        isDead = true;
        //Play Death animation and stuff
    }
    public bool CheckIsDead()
    {
        return isDead;
    }
}
