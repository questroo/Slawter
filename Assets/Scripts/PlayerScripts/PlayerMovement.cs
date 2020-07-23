using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    [SerializeField]
    private float gravity = -9.81f;

    private CharacterController controller;

    private float verticalDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalDirection = jumpForce;
            }
        }

        // needs to be looked at
        verticalDirection -= gravity * Time.deltaTime;

        direction.y = verticalDirection;

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
}