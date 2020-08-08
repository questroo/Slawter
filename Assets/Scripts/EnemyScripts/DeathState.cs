using System;
using UnityEngine;
using UnityEngine.AI;

public class DeathState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private float turnSpeed;
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;
    public float distanceBeforeAttacking = 10.0f;
    public float distanceBeforeChasingPlayer = 18.0f;

    public DeathState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        return typeof(DeathState);
    }
}
