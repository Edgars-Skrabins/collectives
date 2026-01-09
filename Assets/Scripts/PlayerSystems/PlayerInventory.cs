using System.Collections.Generic;
using Collectives.ScriptableObjects;
using UnityEngine;

namespace Collectives
{
    public class PlayerInventory : MonoBehaviour
    {
        private readonly List<ValuableDataSO> m_pickedUpValuables = new List<ValuableDataSO>();

        public void AddValuable(ValuableDataSO _valuable)
        {
            m_pickedUpValuables.Add(_valuable);
        }
    }
}