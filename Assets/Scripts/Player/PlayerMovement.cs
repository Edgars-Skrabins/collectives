using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController m_controller;
    [SerializeField] private float m_moveSpeed;

    private void FixedUpdate()
    {
        HandleMovement(GetMovementDirection());
    }

    private void HandleMovement(Vector3 _moveDirection)
    {
        Move(_moveDirection);
    }

    private void Move(Vector2 _input)
    {
        Vector3 movementVector = transform.right * _input.x + transform.forward * _input.y;
        m_controller.Move(movementVector * m_moveSpeed * Time.deltaTime);
    }

    private Vector2 GetMovementDirection()
    {
        Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        return moveInput;
    }
}
