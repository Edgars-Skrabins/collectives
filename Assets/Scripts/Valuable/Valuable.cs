using UnityEngine;

namespace Collectives.Valuable
{
    public class Valuable : Interactable
    {
        [Space(5)]
        [Header("Valuable settings")]
        [Space(5)]
        [SerializeField] private EWeightClasses m_weightClass;
        [SerializeField] private int m_monetaryValue;
        [SerializeField] private int m_experienceValue;

        public int GetWeightSpeedReduction()
        {
            return (int)m_weightClass;
        }

        public int GetMonetaryValue()
        {
            return m_monetaryValue;
        }

        public int GetExperienceValue()
        {
            return m_experienceValue;
        }
    }
}
