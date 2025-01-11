using System;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class Player : Character
    {
        [SerializeField] private PlayerGroundCheck m_groundCheck;
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private PlayerStamina m_staminaSystem;
        [SerializeField] private PlayerMovement m_movementSystem;
        private bool m_isSprinting;
        public event Action OnStartSprint;
        public event Action OnStopSprint;

        public bool GetIsGrounded()
        {
            return m_groundCheck != null && m_groundCheck.IsGrounded();
        }

        public bool GetIsSprinting()
        {
            return m_isSprinting;
        }
        public void SetSprinting(bool _value)
        {
            if (m_isSprinting == _value) return;

            m_isSprinting = _value;
            if (m_isSprinting)
            {
                OnStartSprint?.Invoke();
            }
            else
            {
                OnStopSprint?.Invoke();
            }
        }

        public CharacterController GetCharacterController()
        {
            return m_controller;
        }
        public PlayerStamina GetStaminaSystem()
        {
            return m_staminaSystem;
        }
        public PlayerMovement GetMovementSystem()
        {
            return m_movementSystem;
        }
    }
}
