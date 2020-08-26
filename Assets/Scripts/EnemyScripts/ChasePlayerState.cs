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

        if (Vector3.Angle(Player.transform.position - enemy.transform.position, enemy.transform.forward) <= enemy.ranges.fieldOfViewAngle * 0.5f)
        {
            // Gets all the walls in order by distance from the enemy
            var walls = GameObject.FindGameObjectsWithTag("Wall").OrderByDescending(wall => (transform.position - wall.transform.position).sqrMagnitude).ToList();
            Wall closestWall = null;
            foreach(var wall in walls)
            {
                if (!wall.GetComponent<Wall>().IsOccupied)
                {
                    closestWall = wall.GetComponent<Wall>();
                }
            }

            if (closestWall != null)
            {
                var positionBehindWall = closestWall.transform.position + (closestWall.transform.position - Player.transform.position).normalized;
                navMeshAgent.SetDestination(positionBehindWall);
                closestWall.GetComponent<Wall>().IsOccupied = true;
                enemy.currentlyOccupiedWall = closestWall.GetComponent<Wall>();
                return typeof(TakeCoverState);
            }

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
