using UnityEngine;
using UnityEngine.Events;

namespace Collectives
{
    public class TriggerCollisionBroadcaster : MonoBehaviour
    {
        public UnityEvent<Collider> OnTriggerEnterEvent;

        private void OnTriggerEnter(Collider _collider)
        {
            OnTriggerEnterEvent?.Invoke(_collider);
        }
    }
}