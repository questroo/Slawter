using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> availableStates;
    GameObject player;
    TextMesh debugText; 
    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        //debugText = GetComponentInChildren<TextMesh>();
    }
    public void SetStates(Dictionary<Type, BaseState> states)
    {
        availableStates = states;
    }

    private void Update()
    {
        //debugText.transform.LookAt(new Vector3(player.transform.position.x, debugText.transform.position.y, player.transform.position.z));
        if (CurrentState == null)
        {
            CurrentState = availableStates[typeof(FindNexusState)];
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null &&
            nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
        //debugText.text = CurrentState.ToString();
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState = availableStates[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
