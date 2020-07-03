using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "Unity-DOOM/States/Chase", order = 3)]

    public class ChaseState : AbstractFSMState
    {
        float cooldownDuration = 0.0f;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.CHASE;
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }

        public override bool EnterState()
        {
            EnteredState = base.EnterState();

            if(EnteredState)
            {
                Debug.Log("ENTERED CHASE STATE");
            }

            return EnteredState;
        }

        public override void UpdateState()
        {
            if(EnteredState)
            {
                float distance = Vector3.Distance(player.transform.position, _navMeshAgent.transform.position);
                
                if(distance >= _enemy.chaseRange)
                {
                    _fsm.EnterState(FSMStateType.ALERT);
                    return;
                }
                else if(distance <= _enemy.chaseRange)
                {
                    _navMeshAgent.SetDestination(player.transform.position);
                }
                
            }
        }
    }
}
