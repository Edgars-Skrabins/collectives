using UnityEngine;

namespace Collectives
{
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] private float m_maxStamina;
        [SerializeField] private float m_staminaRegenRate;
        [SerializeField] private float m_standingRegenMultiplier;
        [SerializeField] private float m_staminaDrainRate;

        private float m_currentStamina;

        private void Start()
        {
            m_currentStamina = m_maxStamina;
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

        public bool CanSprint()
        {
            return m_currentStamina > 0;
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