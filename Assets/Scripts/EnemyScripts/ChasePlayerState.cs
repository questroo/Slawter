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
            animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < enemy.ranges.attackRange)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("Running", false);
            animator.SetBool("Shooting", true);
            return typeof(AttackPlayerState);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > enemy.ranges.chaseRange)
        {
            navMeshAgent.SetDestination(nexus.transform.position);
            return typeof(FindNexusState);
        }
        return typeof(ChasePlayerState);
    }
}
