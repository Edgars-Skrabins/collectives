using Collectives.ValuableSystems;
using UnityEngine;

namespace Collectives.DropOffZone
{
    public class DropOffZone : MonoBehaviour
    {
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
            _valuable.Collect();
        }

        private void OnDisable()
        {
            m_triggerCollisionBroadcaster.OnTriggerEnterEvent -= OnItemCollisionInDropOff;
        }
    }
}