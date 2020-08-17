using System;
using System.Collections.Generic;

public class FleshEnemy : Enemy
{
    public override void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(FindNexusState), new FindNexusState(this)},
            { typeof(AttackNexusState), new AttackNexusState(this)},
            { typeof(DeathState), new DeathState(this)}
        };
        GetComponent<StateMachine>().SetStates(states);
    }
}
