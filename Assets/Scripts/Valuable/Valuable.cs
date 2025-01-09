using UnityEngine;

namespace Collectives.Valuable
{
    public struct ValuableData
    {
        public string name;
        public EWeightClasses weightClass;
        public int monetaryValue;
        public int experienceValue;
        public int id;
    }

    public class Valuable : Interactable
    {
        [Space(5)]
        [Header("Valuable settings")]
        [Space(5)]
        [SerializeField] private string m_valuableName;
        [SerializeField] private EWeightClasses m_weightClass;
        [SerializeField] private int m_monetaryValue;
        [SerializeField] private int m_experienceValue;
    }
}