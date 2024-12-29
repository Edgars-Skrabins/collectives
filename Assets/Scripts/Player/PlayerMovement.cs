using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 5f;

    private CharacterController m_controller;
    private Vector3 m_moveInput;

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        m_moveInput = GetMovementDirection();
    }

    private void FixedUpdate()
    {
        HandleMovement(m_moveInput);
    }

    private void HandleMovement(Vector3 _moveDirection)
    {
        Move(_moveDirection);
    }

    private Vector2 GetMovementDirection()
    {
        Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        return moveInput;
    }

    void Move(Vector2 _input)
    {
        Vector3 move = transform.right * _input.x + transform.forward * _input.y;
        m_controller.Move(move * m_moveSpeed * Time.deltaTime);
    }
}
