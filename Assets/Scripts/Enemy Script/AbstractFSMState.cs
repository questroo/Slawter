using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class AbstractFSMState : ScriptableObject
{

    public ExecutionState executionState { get; protected set; }
    
    public virtual void OnEnable()
    {
        executionState = ExecutionState.NONE;
    }

    //A: Enter states successfully
    public virtual bool EnterState()
    {
        executionState = ExecutionState.ACTIVE;
        return true;
    }

    //A: Updates current state in the state machine
    public abstract void UpdateState();
    
    
    //A: Exits State successfully
    public virtual bool ExitState()
    {
        executionState = ExecutionState.COMPLETED;
        return true;
    }
}
