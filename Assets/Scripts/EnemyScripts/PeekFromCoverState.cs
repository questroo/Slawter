using System;
using UnityEngine;
using UnityEngine.AI;

public class PeekFromCoverState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private Enemy enemy;

    public PeekFromCoverState(Enemy enemy) : base(enemy.gameObject)
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

        return typeof(PeekFromCoverState);
    }
}
