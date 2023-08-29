using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRigid : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 7f;
    public float gravity = -9.81f;
    public LayerMask groundMask;

    private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;

    private void Start()
    {
        Initial();
    }

    private void Initial()
    {
        controller = GetComponent<CharacterController>();
      
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var move = transform.right * horizontal + transform.forward * vertical;

        var currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        var isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;
    }

}
