using System;
using UnityEngine;

public abstract class BaseState
{
    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;
    }
    protected GameObject gameObject;
    protected Transform transform;
    protected Animator Animator => gameObject.GetComponentInChildren<Animator>();
    protected GameObject Player => GameObject.FindGameObjectWithTag("Player");
    protected GameObject Nexus => GameObject.FindObjectOfType<NexusHealth>().gameObject;

    public abstract Type Tick();
}
