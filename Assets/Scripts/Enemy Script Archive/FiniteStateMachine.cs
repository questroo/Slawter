using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy_Script
{
    public class FiniteStateMachine : MonoBehaviour
    {
        //[SerializeField]
        //AbstractFSMState startingState;
        AbstractFSMState currentState;

        [SerializeField]
        List<AbstractFSMState> _validState;
        Dictionary<FSMStateType, AbstractFSMState> _fsmStates;

        public void Awake()
        {
            currentState = null;

            _fsmStates = new Dictionary<FSMStateType, AbstractFSMState>();

            NavMeshAgent navMeshAgent = this.GetComponent<NavMeshAgent>();
            Enemy enemy = this.GetComponent<Enemy>();

            foreach (AbstractFSMState state in _validState)
            {
                state.SetExecutingFSM(this);
                state.SetExecutingEnemy(enemy);
                state.SetNavMeshAgent(navMeshAgent);
                _fsmStates.Add(state.StateType, state);
            }
        }

        public void Start()
        {
            EnterState(FSMStateType.IDLE);
        }

        public void Update()
        {
            if(currentState != null)
            {
                currentState.UpdateState();
            }
        }

        #region
        public void EnterState(AbstractFSMState nextState)
        {
            if(nextState == null)
            {
                return;
            }
            if(currentState != null)
            {
                currentState.ExitState();
            }

            currentState = nextState;
            currentState.EnterState();
        }

        public void EnterState(FSMStateType stateType)
        {
            if(_fsmStates.ContainsKey(stateType))
            {
                AbstractFSMState nextState = _fsmStates[stateType];
                
                EnterState(nextState);
            }
        }

        #endregion

    }
}
