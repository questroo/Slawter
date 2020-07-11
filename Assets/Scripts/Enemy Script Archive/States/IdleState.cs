using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Unity-DOOM/States/Idle", order = 1)]
    public class IdleState : AbstractFSMState
    {
        [SerializeField]
        float _idleDruation = 3f;
        float _totalDuration;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }


        public override bool EnterState()
        {
            EnteredState = base.EnterState();
            if (EnteredState)
            {
                Debug.Log("ENTER IDLED STATE");
                _totalDuration = 0f;
            }

            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                _totalDuration += Time.deltaTime;
                Debug.Log("UPDATING IDLE STATE " + _totalDuration + " seconds.");

                if(_totalDuration >= _idleDruation)
                {
                    _fsm.EnterState(FSMStateType.PATROL);
                }
            }
        }

        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("EXIT IDLED STATE");
            return true;
        }
    }
}
