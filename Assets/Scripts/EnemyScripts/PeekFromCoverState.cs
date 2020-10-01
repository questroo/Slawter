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
        Animator.SetBool("Running", true);
        navMeshAgent.SetDestination(Player.transform.position);
        if (enemy.GetHP() <= 0.0f)
        {
            var enemyColliders = enemy.GetComponentsInChildren<Collider>();
            foreach (Collider col in enemyColliders)
            {
                col.enabled = false;
            }
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(enemy.shootFromPosition.position, (Player.transform.position - enemy.shootFromPosition.position).normalized);
        var distance = Vector3.Distance(enemy.shootFromPosition.position, Player.transform.position);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.transform.GetComponent<PlayerMovement>())
            {
                enemy.SetTarget(Player.transform);
                Animator.SetBool("Running", false);
                Animator.SetBool("TakeCover", false);
                Animator.SetBool("Shooting", true);
                return typeof(AttackPlayerState);
            }
        }
        return typeof(PeekFromCoverState);
    }
}
