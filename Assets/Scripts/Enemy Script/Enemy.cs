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
        // Range
        public float chaseRange;
        public float explosionRange;
        public float alertRange;
        
        [SerializeField]
        EnemyPatrolPoint[] patrolPoints;

        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStateMachine;

        
        public void Awake()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();
            finiteStateMachine = this.GetComponent<FiniteStateMachine>();
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
