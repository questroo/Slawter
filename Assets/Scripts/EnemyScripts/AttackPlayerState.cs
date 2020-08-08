using System;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayerState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;


    public AttackPlayerState(Enemy enemy) : base(enemy.gameObject)
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
        if (Vector3.Distance(transform.position, player.transform.position) > enemy.ranges.attackRange &&
            Vector3.Distance(transform.position, player.transform.position) <= enemy.ranges.chaseRange)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Shooting", false);
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(player.transform.position);
            return typeof(ChasePlayerState);
        }
        return typeof(AttackPlayerState);
    }
}
