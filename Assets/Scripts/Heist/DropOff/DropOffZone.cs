using UnityEngine;
using UnityEngine.Events;

namespace Collectives
{
    public class DropOffZone : MonoBehaviour
    {
        public Collider m_collider;
        public UnityEvent OnItemEnterDropOff;

        public void OnItemCollisionInDropOff(Collider _collider)
        {
            // if (_collider.TryGetComponent(IVa))
        }
    }
}