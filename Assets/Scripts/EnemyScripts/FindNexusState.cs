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
        navMeshAgent.SetDestination(Nexus.transform.position);
        Animator.SetBool("Running", true);
        if (enemy.GetHP() <= 0.0f)
        {
            enemy.GetComponent<Collider>().enabled = false;
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (enemy.GetType().Name != typeof(FleshEnemy).Name)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < enemy.ranges.attackRange)
            {
                enemy.SetTarget(Player.transform);
                Animator.SetBool("Running", false);
                Animator.SetBool("Shooting", true);
                return typeof(AttackPlayerState);
            }
            if (Vector3.Distance(transform.position, Player.transform.position) < enemy.ranges.chaseRange)
            {
                Animator.SetBool("Shooting", true);
                navMeshAgent.SetDestination(Player.transform.position);
                return typeof(ChasePlayerState);
            }
        }
        if (Vector3.Distance(transform.position, navMeshAgent.destination) < enemy.ranges.attackRange)
        {
            enemy.SetTarget(Nexus.transform);
            Animator.SetBool("Running", false);
            Animator.SetBool("Shooting", true);
            navMeshAgent.isStopped = true;
            return typeof(AttackNexusState);
        }
        return typeof(FindNexusState);
    }
}
