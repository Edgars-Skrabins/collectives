using System;
using UnityEngine;

namespace Collectives.HelperComponents
{
    public class TriggerCollisionBroadcaster : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent;

        private void OnTriggerEnter(Collider _collider)
        {
            OnTriggerEnterEvent?.Invoke(_collider);
        }
    }
}