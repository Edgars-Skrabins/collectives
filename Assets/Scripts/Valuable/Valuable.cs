using Collectives.DropOffZone;
using Collectives.ScriptableObjects;
using UnityEngine;

namespace Collectives.ValuableSystems
{
    public class Valuable : Interactable, IValuable
    {
        [SerializeField] private ValuableDataSO m_valuableData;

        public void Collect(DropOffZoneData _dropOffZoneData)
        {
        }

        public ValuableDataSO GetValuableData()
        {
            return m_valuableData;
        }
    }
}