using UnityEngine;

namespace Collectives.PlayerSystems

{
    [RequireComponent(typeof(CharacterController), typeof(PlayerGroundCheck))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private PlayerGroundCheck m_groundCheck;
        [SerializeField] private CharacterController m_controller;
        [Space]
        [SerializeField] private float m_jumpHeight;
        [SerializeField] private float m_gravity;

        private Vector3 m_velocity;

        private void Update()
        {
            Jump(Input.GetButtonDown("Jump"));
        }

        private void Jump(bool _jumpInput)
        {
            ApplyGroundedForce();

            if (_jumpInput && m_groundCheck.IsGrounded())
            {
                DoJump();
            }

            ApplyGravity();
            m_controller.Move(m_velocity * Time.deltaTime);
        }

        private void DoJump()
        {
            m_velocity.y = Mathf.Sqrt(2f * m_jumpHeight * m_gravity);
        }

        private void ApplyGroundedForce()
        {
            if (m_groundCheck.IsGrounded() && m_velocity.y < 0)
            {
                m_velocity.y = -2f;
            }
        }

        private void ApplyGravity()
        {
            m_velocity.y -= m_gravity * Time.deltaTime;
        }
    }
}