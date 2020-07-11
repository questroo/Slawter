using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "AlertState", menuName = "Unity-DOOM/States/Alert", order = 4)]
    public class AlertState : AbstractFSMState
    {

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.ALERT;
        }

        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
