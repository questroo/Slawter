﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage = 10.0f;

    public Animator meleeAnimator;
    public Collider meleeCollider;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            meleeAnimator.SetTrigger("MeleeAttack");
        }
    }

    public void TriggerBoxEnable()
    {
        meleeCollider.enabled = true;
    }

    public void TriggerBoxDisable()
    {
        meleeCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyHealth>())
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
