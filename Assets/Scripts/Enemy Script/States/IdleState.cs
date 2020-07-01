using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName ="Unity-DOOM/States/Idle", order = 1)]
    public class IdleState : AbstractFSMState
    {
        public override void OnEnable()
        {
            base.OnEnable();
        }

        public override bool EnterState()
        {
            base.EnterState();
            Debug.Log("ENTER IDLED STATE");
            return true;
        }

        public override void UpdateState()
        {
            Debug.Log("UPDATING IDLE STATE");
        }
        
        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("EXIT IDLED STATE");
            return true;
        }
    }
}
