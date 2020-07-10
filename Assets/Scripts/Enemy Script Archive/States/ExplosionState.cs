using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy_Script.States
{
    [CreateAssetMenu(fileName = "ExplosionState", menuName = "Unity-DOOM/States/Explode", order = 5)]

    public class ExplosionState : AbstractFSMState
    {
        Health health;

        

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.EXPLODE;
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                if (Vector3.Distance(player.transform.position, _enemy.transform.position) <= _enemy.explosionRange)
                {
                    Debug.Log("EXPLODE!!!");
                    //_enemy.PlayerHealth().TakeDamage(_enemy.explosionDamage);
                    Destroy(_enemy.gameObject);
                }
                EnteredState = true;
            }
            return EnteredState;
        }

        public override void UpdateState()
        {
          
        }
    }
}
