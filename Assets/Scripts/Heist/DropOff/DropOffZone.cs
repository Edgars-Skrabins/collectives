using System;
using Collectives.ValuableSystems;
using UnityEngine;

namespace Collectives.DropOffZone
{
    public class DropOffZone : MonoBehaviour
    {
        public event Action<IValuable> OnValuableEnterDropOff;
        [SerializeField] private TriggerCollisionBroadcaster m_triggerCollisionBroadcaster;

        private void OnEnable()
        {
            m_triggerCollisionBroadcaster.OnTriggerEnterEvent += OnItemCollisionInDropOff;
        }

        private void OnItemCollisionInDropOff(Collider _collider)
        {
            if (_collider.TryGetComponent(out IValuable valuable))
            {
                HandleValuableCollision(valuable);
            }
        }

        private void HandleValuableCollision(IValuable _valuable)
        {
            OnValuableEnterDropOff?.Invoke(_valuable);
            _valuable.Collect();
        }

        private void OnDisable()
        {
            m_triggerCollisionBroadcaster.OnTriggerEnterEvent -= OnItemCollisionInDropOff;
        }
    }
}