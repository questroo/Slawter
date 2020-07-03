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

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.CHASE;
        }

        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
