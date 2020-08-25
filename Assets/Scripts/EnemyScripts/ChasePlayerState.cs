using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private float turnSpeed;
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;

    public ChasePlayerState(Enemy enemy) : base(enemy.gameObject)
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

        if(Vector3.Angle(Player.transform.position - enemy.transform.position, enemy.transform.forward) <= enemy.ranges.fieldOfViewAngle * 0.5f)
        {
            // Find the nearest wall
            var closestWall = GameObject.FindGameObjectsWithTag("Wall").OrderBy(wall => (transform.position - wall.transform.position).sqrMagnitude).First().transform;
            var positionBehindWall = closestWall.transform.position + (closestWall.transform.position - Player.transform.position).normalized;
            navMeshAgent.SetDestination(positionBehindWall);

            return typeof(TakeCoverState);
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < enemy.ranges.attackRange)
        {
            enemy.SetTarget(Player.transform);
            navMeshAgent.isStopped = true;
            Animator.SetBool("Running", false);
            Animator.SetBool("Shooting", true);
            return typeof(AttackPlayerState);
        }
        if (Vector3.Distance(transform.position, Player.transform.position) > enemy.ranges.chaseRange)
        {
            navMeshAgent.SetDestination(Nexus.transform.position);
            return typeof(FindNexusState);
        }
        return typeof(ChasePlayerState);
    }
}
