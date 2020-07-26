using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateBase : StateMachineBehaviour
{
    private PlayerMovement playerMovement;
    private Gun gun;
    
    public PlayerMovement GetPlayerMovement(Animator animator)
    {
        if (playerMovement == null)
        {
            playerMovement = animator.GetComponentInParent<PlayerMovement>();
        }
        return playerMovement;
    }
    public Gun GetGun(Animator animator)
    {
        if (gun == null)
        {
            gun = animator.GetComponentInChildren<Gun>();
        }
        return gun;
    }
}
