using System;
using UnityEngine;
using UnityEngine.AI;

public class FindNexusState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private float turnSpeed;
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;


    public FindNexusState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        navMeshAgent.SetDestination(nexus.transform.position);
        animator.SetBool("Running", true);
        if (enemy.GetHP() <= 0.0f)
        {
            enemy.GetComponent<Collider>().enabled = false;
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (Vector3.Distance(transform.position, navMeshAgent.destination) < enemy.ranges.attackRange)
        {
            enemy.SetTarget(nexus.transform);
            animator.SetBool("Running", false);
            animator.SetBool("Shooting", true);
            navMeshAgent.isStopped = true;
            return typeof(AttackNexusState);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < enemy.ranges.attackRange)
        {
            enemy.SetTarget(player.transform);
            animator.SetBool("Running", false);
            animator.SetBool("Shooting", true);
            return typeof(AttackPlayerState);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < enemy.ranges.chaseRange)
        {
            animator.SetBool("Shooting", true);
            navMeshAgent.SetDestination(player.transform.position);
            return typeof(ChasePlayerState);
        }
        return typeof(FindNexusState);
    }
}
