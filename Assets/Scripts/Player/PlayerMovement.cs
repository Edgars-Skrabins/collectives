using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Player m_player;

        private CharacterController m_controller;
        private PlayerStamina m_staminaSystem;
        private PlayerGroundCheck m_groundCheck;

        [SerializeField] private float m_walkSpeed;
        [SerializeField] private float m_sprintSpeedMultiplier;

        private float m_moveSpeed;

        private float m_moveSpeedMultiplier;
        private bool m_isSprinting;

        private void Awake()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            m_controller = m_player.GetCharacterController();
            m_staminaSystem = m_player.GetPlayerStamina();
            m_groundCheck = m_player.GetPlayerGroundCheck();
        }

        public void SetMoveSpeedMultiplier(float _multiplierValue)
        {
            m_moveSpeedMultiplier = _multiplierValue;
        }

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
            m_controller.Move(movementVector * m_moveSpeed * m_moveSpeedMultiplier * Time.deltaTime);
        }

        private Vector2 GetMovementDirection()
        {
            Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveInput;
        }
    }
}