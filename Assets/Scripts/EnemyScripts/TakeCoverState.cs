using System;
using UnityEngine;
using UnityEngine.AI;

public class TakeCoverState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private Enemy enemy;
    private float timeInCover = 0.0f;
    bool atDestination = false;

    public TakeCoverState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        if (atDestination)
        {
            timeInCover += Time.deltaTime;
            if (timeInCover > 3.0f)
            {
                return typeof(PeekFromCoverState);
            }
        }
        if (enemy.GetHP() <= 0.0f)
        {
            enemy.GetComponent<Collider>().enabled = false;
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (navMeshAgent.remainingDistance <= 0.1f && !atDestination)
        {
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", false);
            Animator.SetBool("TakingCoverIdle", false);
            Animator.SetBool("Emerging", true);
            atDestination = true;
            //return typeof(PeekFromCoverState);
        }
        if (navMeshAgent.remainingDistance < 3.0f && !Animator.GetBool("TakeCover") && !Animator.GetBool("Emerging"))
        {
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", true);
        }
        return typeof(TakeCoverState);
    }
}
