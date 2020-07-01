using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.Enemy_Script.PatrolPoint;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "Unity-DOOM/States/Idle", order = 2)]
    public class PatrolState : AbstractFSMState
    {
        EnemyPatrolPoint[] patrolPoints;
        int patrolPointIndex;

        public override void OnEnable()
        {
            base.OnEnable();
            patrolPointIndex = 1;
        }

        public override bool EnterState()
        {
            if(base.EnterState())
            {

            }
            return base.EnterState();
        }

        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
