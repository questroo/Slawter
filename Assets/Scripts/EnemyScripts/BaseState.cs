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
    protected Animator animator => gameObject.GetComponentInChildren<Animator>();
    protected GameObject player => GameObject.FindGameObjectWithTag("Player");
    protected GameObject nexus => GameObject.FindObjectOfType<NexusHealth>().gameObject;

    public abstract Type Tick();
}
