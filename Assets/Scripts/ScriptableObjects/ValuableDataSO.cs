using Collectives.ValuableSystems;
using UnityEngine;

namespace Collectives.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ValuableData", menuName = "Collectives/ValuableData", order = 0)]
    public class ValuableDataSO : ScriptableObject
    {
        public string valuableName;
        public EWeightClasses weightClass;
        public int monetaryValue;
        public int experienceValue;
    }
}