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
        Animator.SetBool("Shooting", false);
        if (atDestination)
        {
            timeInCover += Time.deltaTime;
            if (timeInCover > 1.5f)
            {
                enemy.currentlyOccupiedWall.IsOccupied = false;
                enemy.currentlyOccupiedWall = null;
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
            Animator.SetTrigger("Emerge");
            //Animator.SetBool("TakeCover", false);
            //Animator.SetBool("TakingCoverIdle", false);
            atDestination = true;
        }
        else if (navMeshAgent.remainingDistance < 3.0f && !Animator.GetBool("TakeCover") && !Animator.GetBool("Emerging") && !atDestination)
        {
            Animator.SetBool("Sprinting", false);
            Animator.SetBool("Running", false);
            Animator.SetBool("TakeCover", true);
        }
        return typeof(TakeCoverState);
    }
}
