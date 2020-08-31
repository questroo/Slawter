using System;
using UnityEngine;
using UnityEngine.AI;

public class AttackNexusState : BaseState
{
    private NavMeshAgent navMeshAgent => gameObject.GetComponent<NavMeshAgent>();
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Enemy");
    private Enemy enemy;
    


    public AttackNexusState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        if(enemy.GetHP() <= 0.0f)
        {
            var enemyColliders = enemy.GetComponentsInChildren<Collider>();
            foreach (Collider col in enemyColliders)
            {
                col.enabled = false;
            }
            enemy.SetTarget(null);
            navMeshAgent.isStopped = true;
            Animator.SetTrigger("Dead");
            return typeof(DeathState);
        }
        return typeof(AttackNexusState);
    }
}
