using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy_Script.PatrolPoint
{
    public class EnemyPatrolPoint : MonoBehaviour
    {
        [SerializeField]
        protected float debugDrawRadius = 1.0f;

        [SerializeField]
        protected float connectivityRadius = 50.0f;

        List<EnemyPatrolPoint> connections;

        public void Start()
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            connections = new List<EnemyPatrolPoint>();

            for (int i = 0; i < allWaypoints.Length; i++)
            {
                EnemyPatrolPoint nextWaypoint = allWaypoints[i].GetComponent<EnemyPatrolPoint>();

                if (nextWaypoint != null)
                {
                    if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectivityRadius && nextWaypoint != this)
                    {
                        connections.Add(nextWaypoint);
                    }
                }
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, connectivityRadius);
        }

        public EnemyPatrolPoint NextWaypoint(EnemyPatrolPoint previousWaypoint)
        {
            if (connections.Count == 0)
            {
                Debug.Log("Not enough waypoint count");
                return null;
            }
            else if (connections.Count == 1 && connections.Contains(previousWaypoint))
            {
                return previousWaypoint;
            }
            else
            {
                EnemyPatrolPoint nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, connections.Count);
                    nextWaypoint = connections[nextIndex];

                } while (nextWaypoint == previousWaypoint);

                return nextWaypoint;
            }

        }

    }
}
