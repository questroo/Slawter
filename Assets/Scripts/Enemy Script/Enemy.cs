using Assets.Scripts.Enemy_Script.PatrolPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy_Script
{
    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]

    public class Enemy : MonoBehaviour
    {
        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStateMachine;

        [SerializeField]
        EnemyPatrolPoint[] patrolPoints;

        public void Awake()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();
            finiteStateMachine = this.GetComponent<FiniteStateMachine>();
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public EnemyPatrolPoint[] PatrolPoints
        {
            get
            {
                return patrolPoints;
            }
        }
    }
}
