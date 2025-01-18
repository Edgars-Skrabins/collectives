using Collectives.ScriptableObjects;
using UnityEngine;

namespace Collectives.ValuableSystems
{
    public class Valuable : Interactable
    {
        [SerializeField] private ValuableDataSO m_valuableData;

        public ValuableDataSO GetValuableData()
        {
            return m_valuableData;
        }
    }
}