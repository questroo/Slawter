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
        public float explosionDamage;

        [SerializeField]
        EnemyPatrolPoint[] patrolPoints;

        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStateMachine;

        [SerializeField]
        private Health playerHealth;
        

        public void Awake()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();
            finiteStateMachine = this.GetComponent<FiniteStateMachine>();
            playerHealth = GetComponent<Health>();
        }

        public EnemyPatrolPoint[] PatrolPoints
        {
            get
            {
                return patrolPoints;
            }
        }

        public Health PlayerHealth()
        {
            return playerHealth;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRange);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, explosionRange);

        }
    }
}
