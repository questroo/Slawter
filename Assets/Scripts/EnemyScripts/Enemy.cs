using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HP hp;
    private float currentHP;
    public EnemyAIRanges ranges;

    [SerializeField] private LayerMask layerMask;

    public Transform Target { get; private set; }

    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        currentHP = hp.maxHP;
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(FindNexusState), new FindNexusState(this)},
            { typeof(ChasePlayerState), new ChasePlayerState(this)},
            { typeof(AttackPlayerState), new AttackPlayerState(this)},
            { typeof(AttackNexusState), new AttackNexusState(this)},
            { typeof(DeathState), new DeathState(this)}
        };
        GetComponent<StateMachine>().SetStates(states);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    public float GetHP()
    {
        return currentHP;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void Die()
    {
        //Play Death animation and stuff
    }
}
