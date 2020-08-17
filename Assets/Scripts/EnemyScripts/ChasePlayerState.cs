using System;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private float turnSpeed;
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;

    public ChasePlayerState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        if (enemy.GetHP() <= 0.0f)
        {
            enemy.GetComponent<Collider>().enabled = false;
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < enemy.ranges.attackRange)
        {
            enemy.SetTarget(Player.transform);
            navMeshAgent.isStopped = true;
            Animator.SetBool("Running", false);
            Animator.SetBool("Shooting", true);
            return typeof(AttackPlayerState);
        }
        if (Vector3.Distance(transform.position, Player.transform.position) > enemy.ranges.chaseRange)
        {
            navMeshAgent.SetDestination(Nexus.transform.position);
            return typeof(FindNexusState);
        }
        return typeof(ChasePlayerState);
    }
}
