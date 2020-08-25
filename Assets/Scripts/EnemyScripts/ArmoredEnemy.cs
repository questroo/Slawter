using System;
using System.Collections.Generic;

public class ArmoredEnemy : Enemy
{
    public override void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(FindNexusState), new FindNexusState(this)},
            { typeof(ChasePlayerState), new ChasePlayerState(this)},
            { typeof(TakeCoverState), new TakeCoverState(this)},
            { typeof(PeekFromCoverState), new PeekFromCoverState(this)},
            { typeof(AttackPlayerState), new AttackPlayerState(this)},
            { typeof(AttackNexusState), new AttackNexusState(this)},
            { typeof(DeathState), new DeathState(this)}
        };
        GetComponent<StateMachine>().SetStates(states);
    }
}
