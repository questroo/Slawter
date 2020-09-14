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
        navMeshAgent.speed = enemy.runMoveSpeed;
        Animator.SetBool("Sprinting", true);
        if (atDestination)
        {
            timeInCover += Time.deltaTime;
            if (timeInCover > 3.0f)
            {
                enemy.currentlyOccupiedWall.IsOccupied = false;
                enemy.currentlyOccupiedWall = null;
                Animator.SetBool("Sprinting", false);
                navMeshAgent.speed = enemy.walkMoveSpeed;
                return typeof(PeekFromCoverState);
            }
        }
        if (enemy.GetHP() <= 0.0f)
        {
            var enemyColliders = enemy.GetComponentsInChildren<Collider>();
            foreach (Collider col in enemyColliders)
            {
                col.enabled = false;
            }
            navMeshAgent.speed = enemy.walkMoveSpeed;
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        if (navMeshAgent.remainingDistance <= 0.1f && !atDestination)
        {
            Animator.SetBool("Sprinting", false);
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", false);
            Animator.SetBool("TakingCoverIdle", false);
            Animator.SetBool("Emerging", true);
            atDestination = true;
        }
        if (navMeshAgent.remainingDistance < 3.0f && !Animator.GetBool("TakeCover") && !Animator.GetBool("Emerging"))
        {
            Animator.SetBool("Sprinting", false);
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", true);
        }
        return typeof(TakeCoverState);
    }
}
