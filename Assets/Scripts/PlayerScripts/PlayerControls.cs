using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private GameControls controls;
    private Vector3 moveDirection;

    private void Awake()
    {
        if(controls == null)
        {
            controls = new GameControls();
        }
    }

    private void Start()
    {
        controls.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        controls.Player.Shoot.performed += ctx => Shoot();
    }

    private void Update()
    {
        print(moveDirection);
    }

    void Shoot()
    {
        print("Shoot");
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
