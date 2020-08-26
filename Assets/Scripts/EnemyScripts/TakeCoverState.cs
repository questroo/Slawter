using System;
using UnityEngine;
using UnityEngine.AI;

public class TakeCoverState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private Enemy enemy;

    public TakeCoverState(Enemy enemy) : base(enemy.gameObject)
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
        if (navMeshAgent.remainingDistance < 3.0f && !Animator.GetBool("TakeCover"))
        {
            if (navMeshAgent.remainingDistance <= 0.01f)
            {
                Animator.SetBool("Running", false);
                Animator.SetBool("TakeCover", false);
                Animator.SetBool("TakingCoverIdle", true);
                return typeof(TakeCoverState);
            }
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", true);
        }


        return typeof(TakeCoverState);
    }
}
