using UnityEngine;

namespace Collectives.PlayerSystems
{
    [RequireComponent(typeof(Player))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Player m_player;

        [SerializeField] private float m_walkSpeed;
        [SerializeField] private float m_sprintSpeedMultiplier;
        private float m_moveSpeed;

        private void FixedUpdate()
        {
            HandleMovement(GetMovementDirection());
        }

        private void HandleMovement(Vector3 _moveDirection)
        {
            Move(_moveDirection);
        }

        private void HandleStamina()
        {
            if (m_player.IsSprinting)
            {
                m_player.Stamina.DrainStamina(Time.deltaTime);
            }
        }

        private void Move(Vector2 _input)
        {
            bool canSprint = Input.GetKey(KeyCode.LeftShift) && m_player.Stamina.GetCurrentStamina() > 0 && m_player.IsGrounded;
            m_player.SetSprinting(canSprint);
            m_moveSpeed = m_player.IsSprinting ? m_walkSpeed * m_sprintSpeedMultiplier : m_walkSpeed;

            Vector3 movementVector = transform.right * _input.x + transform.forward * _input.y;
            m_player.Controller.Move(movementVector * m_moveSpeed * Time.deltaTime);
            HandleStamina();
        }

        public Vector2 GetMovementDirection()
        {
            Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveInput;
        }
    }
}