using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private GameControls controls;

    private Vector2 moveVector;
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    [SerializeField]
    private float gravity = -9.81f;
    // Sprinting doubles the speed
    [SerializeField]
    private float sprintSpeed = 2.0f;

    public bool walking = false;
    public bool sprinting = false;

    private CharacterController controller;

    private float verticalDirection;

    private void Awake()
    {
        if (controls == null)
        {
            controls = new GameControls();
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        controls.Player.Sprint.performed += ctx => sprinting = true;
        controls.Player.Sprint.canceled += ctx => sprinting = false;
        controls.Player.Move.performed += ctx => walking = sprinting != true ? true : false;
        controls.Player.Move.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
    }
    void Update()
    {
        if(moveVector == Vector2.zero)
        {
            walking = false;
        }
        float x = moveVector.x;
        float z = moveVector.y;
        Vector3 direction = transform.right * x + transform.forward * z;
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalDirection = jumpForce;
            }
        }
        else
        {
            verticalDirection -= gravity * Time.deltaTime;
        }

        direction.y = verticalDirection;

        if (sprinting && z > 0 && controller.isGrounded)
        {
            GetComponentInChildren<Animator>().SetBool("Sprinting", true);
            controller.Move(direction * moveSpeed * sprintSpeed * Time.deltaTime);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Sprinting", false);
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }
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