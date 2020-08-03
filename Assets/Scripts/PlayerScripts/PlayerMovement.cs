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
    // Sprinting doubles the speed
    [SerializeField]
    private float sprintSpeed = 2.0f;

    public bool walking = false;
    public bool sprinting = false;

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

        if((x != 0 || z != 0) && !sprinting)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }
        if(Input.GetKey(KeyCode.LeftShift) && controller.isGrounded)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
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

        if (sprinting && z > 0)
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
}