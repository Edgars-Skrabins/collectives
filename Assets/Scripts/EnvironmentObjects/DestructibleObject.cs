using Collectives.HealthSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives.EnvironmentObjects
{
    public class DestructibleObject : MonoBehaviour, IDamageable
    {
        public UnityEvent OnObjectDestroyed;
        [SerializeField] private int m_hitsToBreak;
        [SerializeField] private GameObject m_destructionVFX;

        public void Damage(int _damage)
        {
            m_hitsToBreak -= 1;
            if (m_hitsToBreak <= 0)
            {
                DestroyObject();
            }
        }

        private void DestroyObject()
        {
            OnObjectDestroyed?.Invoke();
            m_destructionVFX.SetActive(true);
        }
    }
}