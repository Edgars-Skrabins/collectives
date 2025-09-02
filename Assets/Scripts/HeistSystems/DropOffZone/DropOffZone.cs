using Collectives.HelperComponents;
using Collectives.ValuableSystems;
using UnityEngine;

namespace Collectives.HeistSystems.DropOffZone
{
    public class DropOffZone : MonoBehaviour
    {
        [SerializeField] private TriggerCollisionBroadcaster m_triggerCollisionBroadcaster;
        [SerializeField] private string m_name;
        [SerializeField] private int m_id;

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
            DropOffZoneData dropOffZoneData = new DropOffZoneData
            {
                name = m_name,
                id = m_id
            };

            _valuable.Collect(dropOffZoneData);
        }


        private void OnDisable()
        {
            m_triggerCollisionBroadcaster.OnTriggerEnterEvent -= OnItemCollisionInDropOff;
        }
    }
}