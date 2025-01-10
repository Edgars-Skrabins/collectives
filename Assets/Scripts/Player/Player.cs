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

        public bool IsGrounded => m_groundCheck != null && m_groundCheck.IsGrounded();
        public bool IsSprinting
        {
            get => m_isSprinting;
            private set
            {
                if (m_isSprinting == value) return;

                m_isSprinting = value;
                if (m_isSprinting)
                {
                    OnStartSprint?.Invoke();
                }
                else
                {
                    OnStopSprint?.Invoke();
                }
            }
        }

        public void SetSprinting(bool _isSprinting)
        {
            IsSprinting = _isSprinting;
        }

        public CharacterController Controller => m_controller;
        public PlayerStamina Stamina => m_staminaSystem;
        public PlayerMovement Movement => m_movementSystem;
    }
}
