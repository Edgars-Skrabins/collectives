using System;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives.PlayerSystems
{
    public class Player : Character
    {
        [SerializeField] private PlayerCamera m_cameraSystem;
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private PlayerMovement m_movementSystem;
        [SerializeField] private PlayerStamina m_staminaSystem;
        [SerializeField] private PlayerGroundCheck m_groundCheck;
        [SerializeField] private PlayerCarry m_carry;

        private bool m_isSprinting;

        [Header("Events")]
        public UnityEvent OnStartSprint;

        public UnityEvent OnStopSprint;

        public CharacterController GetCharacterController()
        {
            return m_controller;
        }

        public PlayerMovement GetPlayerMovement()
        {
            return m_movementSystem;
        }

        public PlayerStamina GetPlayerStamina()
        {
            return m_staminaSystem;
        }

        public PlayerGroundCheck GetPlayerGroundCheck()
        {
            return m_groundCheck;
        }

        public PlayerCamera GetCameraSystem()
        {
            return m_cameraSystem;
        }

        public PlayerCarry GetCarrySystem()
        {
            return m_carry;
        }

        public bool IsSprinting()
        {
            return m_isSprinting;
        }

        public void StartSprinting()
        {
            if (!m_isSprinting)
            {
                m_isSprinting = true;
                OnStartSprint?.Invoke();
            }
        }

        public void StopSprinting()
        {
            if (m_isSprinting)
            {
                m_isSprinting = false;
                OnStopSprint?.Invoke();
            }
        }

        public void ResetSpeedMultiplier()
        {
            m_movementSystem.ResetMoveSpeedMultiplier();
        }

        public void SetSpeedMultiplier(float _value)
        {
            m_movementSystem.SetMoveSpeedMultiplier(_value);
        }
    }
}
