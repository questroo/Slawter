using Assets.Scripts.Enemy_Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class AbstractFSMState : ScriptableObject
{
    protected NavMeshAgent _navMeshAgent;
    protected Enemy _enemy;

    public ExecutionState executionState { get; protected set; }

    public virtual void OnEnable()
    {
        executionState = ExecutionState.NONE;
    }

    //A: Enter states successfully
    public virtual bool EnterState()
    {
        bool success = true;
        executionState = ExecutionState.ACTIVE;
        success = (_navMeshAgent != null);
        return success;
    }

    //A: Updates current state in the state machine
    public abstract void UpdateState();


    //A: Exits State successfully
    public virtual bool ExitState()
    {
        executionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent != null)
        {
            _navMeshAgent = navMeshAgent;
        }
    }

    public virtual void SetExecutingEnemy(Enemy enemy)
    {
        if(enemy != null)
        {
            //_enemy
        }
    }
}
