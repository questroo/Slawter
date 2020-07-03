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
    [CreateAssetMenu(fileName = "PatrolState", menuName = "Unity-DOOM/States/Patrol", order = 2)]
    public class PatrolState : AbstractFSMState
    {
        EnemyPatrolPoint[] patrolPoints;
        int patrolPointIndex;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.PATROL;
            patrolPointIndex = -1;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                patrolPoints = _enemy.PatrolPoints;

                if (patrolPoints == null || patrolPoints.Length == 0)
                {
                    Debug.Log("PatrolState: Failed to grab patrol points");
                  
                }
                else
                {

                    if (patrolPointIndex < 0)
                    {
                        patrolPointIndex = UnityEngine.Random.Range(0, patrolPoints.Length);
                    }
                    else
                    {
                        patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;
                    }

                    SetDestination(patrolPoints[patrolPointIndex]);
                    EnteredState = true;
                }
            }
            return EnteredState;
        }

        public override void UpdateState()
        {
            // Need to make sure we've entered the state
            if(EnteredState)
            {
                if(Vector3.Distance(_navMeshAgent.transform.position, patrolPoints[patrolPointIndex].transform.position) <= 1f)
                {
                    _fsm.EnterState(FSMStateType.IDLE);
                }
            }
        }

        private void SetDestination(EnemyPatrolPoint destination)
        {
            if (_navMeshAgent != null && destination != null)
            {
                _navMeshAgent.SetDestination(destination.transform.position);
            }
        }
    }
}
