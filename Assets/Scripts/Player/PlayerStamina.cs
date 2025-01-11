using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] private Player m_player;
        [SerializeField] private float m_maxStamina;
        [SerializeField] private float m_staminaRegenRate;
        [SerializeField] private float m_standingRegenMultiplier;
        [SerializeField] private float m_staminaDrainRate;
        private float m_currentStamina;

        private void Start()
        {
            m_currentStamina = m_maxStamina;
        }

        private void FixedUpdate()
        {
            HandleRegeneration();
        }

        private void HandleRegeneration()
        {
            if (m_currentStamina < m_maxStamina)
            {
                bool isStanding = m_player.GetIsGrounded() && m_player.GetMovementSystem().GetMovementDirection() == Vector2.zero;
                RegenerateStamina(isStanding, Time.deltaTime);
            }
        }

        public void DrainStamina(float _deltaTime)
        {
            m_currentStamina -= m_staminaDrainRate * _deltaTime;
            m_currentStamina = Mathf.Clamp(m_currentStamina, 0, m_maxStamina);
        }

        public void RegenerateStamina(bool _isNotMoving, float _deltaTime)
        {
            float regenRate = _isNotMoving ? m_staminaRegenRate * m_standingRegenMultiplier : m_staminaRegenRate;
            m_currentStamina += regenRate * _deltaTime;
            m_currentStamina = Mathf.Clamp(m_currentStamina, 0, m_maxStamina);
        }

        public float GetCurrentStamina()
        {
            return m_currentStamina;
        }

        public float GetMaxStamina()
        {
            return m_maxStamina;
        }
    }
}
