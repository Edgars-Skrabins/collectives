using UnityEngine;

namespace Collectives.PlayerSystems
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private PlayerStamina m_staminaSystem;
        [SerializeField] private PlayerGroundCheck m_groundCheck;

        [SerializeField] private float m_walkSpeed;
        [SerializeField] private float m_sprintSpeedMultiplier;
        private float m_moveSpeed;

        private bool m_isSprinting;

        private void FixedUpdate()
        {
            HandleMovement(GetMovementDirection());
            HandleStamina();
        }

        private void HandleMovement(Vector3 _moveDirection)
        {
            Move(_moveDirection);
        }

        private void HandleStamina()
        {
            if (m_isSprinting)
            {
                m_staminaSystem.DrainStamina(Time.deltaTime);
            }
            else if (m_staminaSystem.GetCurrentStamina() < m_staminaSystem.GetMaxStamina())
            {
                bool isStanding = m_groundCheck.IsGrounded() && GetMovementDirection() == Vector2.zero;
                m_staminaSystem.RegenerateStamina(isStanding, Time.deltaTime);
            }
        }

        private void Move(Vector2 _input)
        {
            m_isSprinting = Input.GetKey(KeyCode.LeftShift) && m_staminaSystem.CanSprint() && m_groundCheck.IsGrounded();
            m_moveSpeed = m_isSprinting ? m_walkSpeed * m_sprintSpeedMultiplier : m_walkSpeed;

            Vector3 movementVector = transform.right * _input.x + transform.forward * _input.y;
            m_controller.Move(movementVector * m_moveSpeed * Time.deltaTime);
        }

        private Vector2 GetMovementDirection()
        {
            Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveInput;
        }
    }
}