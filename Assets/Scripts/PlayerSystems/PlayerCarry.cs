using Collectives.ValuableSystems;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerCarry : MonoBehaviour
    {
        [SerializeField] private Player m_player;
        [SerializeField] private Transform m_carryTransform;
        [SerializeField] private float m_maxWeightCapacity;

        private float m_currentTotalWeight;
        private Valuable m_currentValuable;
        private List<Valuable> m_pickedValuables;

        private void Awake()
        {
            m_pickedValuables = new List<Valuable>();
        }

        public void SetCurrentValuable(Valuable _newValuable)
        {
            if (m_currentTotalWeight + (float)_newValuable.GetWeightClass() <= m_maxWeightCapacity)
            {
                m_currentValuable = _newValuable;
                PickUp();
            }
        }

        public void DropAll()
        {
            for (int i = 0; i < m_pickedValuables.Count; i++)
            {
                Valuable valuable = m_pickedValuables[i];
                m_currentValuable = valuable;
                Drop();
            }
            m_player.ResetSpeedMultiplier();
        }

        private void Drop()
        {
            m_pickedValuables.Remove(m_currentValuable);
            m_currentValuable.gameObject.SetActive(true);
            m_currentValuable.TryGetComponent(out Rigidbody rb);
            m_currentValuable.gameObject.layer = 0; // Default Layer
            m_currentValuable.transform.SetParent(null);
            rb.isKinematic = false;
            m_currentValuable = null;
        }

        private void PickUp()
        {
            m_pickedValuables.Add(m_currentValuable);
            m_currentValuable.TryGetComponent(out Rigidbody rb);
            rb.isKinematic = true;
            m_currentValuable.gameObject.layer = gameObject.layer;
            m_currentValuable.transform.SetParent(m_carryTransform);
            m_currentValuable.transform.localPosition = Vector3.zero;
            m_currentValuable.transform.localEulerAngles = Vector3.zero;
            m_currentValuable.gameObject.SetActive(false);
            CalculateWeight();
        }

        private void CalculateWeight()
        {
            m_currentTotalWeight = 0f;
            foreach (Valuable valuable in m_pickedValuables)
            {
                m_currentTotalWeight += (float)valuable.GetWeightClass();
            }
            m_player.SetSpeedMultiplier(1 - m_currentTotalWeight / m_maxWeightCapacity);
        }

        private void OnTriggerEnter(Collider _other)
        {
            if (_other.CompareTag("DropOffZone"))
            {
                DropAll();
            }
        }
    }
}