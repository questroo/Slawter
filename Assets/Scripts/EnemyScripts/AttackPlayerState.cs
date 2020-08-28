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
        navMeshAgent.transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        if (enemy.GetHP() <= 0.0f)
        {
            enemy.GetComponent<Collider>().enabled = false;
            enemy.SetTarget(null);
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (Vector3.Distance(transform.position, Player.transform.position) <= enemy.ranges.attackRange)
        {
            Animator.SetBool("Running", false);
            Animator.SetBool("Shooting", true);
            if (enemy.Target == null)
            {
                enemy.SetTarget(Player.transform);
            }
            navMeshAgent.isStopped = true;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) > enemy.ranges.attackRange &&
            Vector3.Distance(transform.position, Player.transform.position) <= enemy.ranges.chaseRange)
        {
            Animator.SetBool("Running", true);
            Animator.SetBool("Shooting", false);
            enemy.SetTarget(null);
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(Player.transform.position);
        }
        if (Vector3.Distance(transform.position, Player.transform.position) > enemy.ranges.chaseRange)
        {
            Animator.SetBool("Running", true);
            Animator.SetBool("Shooting", false);
            enemy.SetTarget(null);
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(Player.transform.position);
            return typeof(FindNexusState);
        }

        return typeof(AttackPlayerState);
    }
}
