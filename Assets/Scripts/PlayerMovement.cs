using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.right * x + transform.forward * z;

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}