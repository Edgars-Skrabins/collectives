using Collectives.PlayerSystems;
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

    [RequireComponent(typeof(Rigidbody))]
    public class Valuable : Interactable
    {
        [Space(5)]
        [Header("Valuable settings")]
        [Space(5)]
        [SerializeField] private string m_valuableName;
        [SerializeField] private EWeightClasses m_weightClass;
        [SerializeField] private int m_monetaryValue;
        [SerializeField] private int m_experienceValue;

        [SerializeField] private GameObject m_mainGFX;
        [SerializeField] private Collider m_mainGFXCollider;
        [SerializeField] private GameObject m_carryGFX;
        [SerializeField] private Collider m_carryGFXCollider;

        public EWeightClasses GetWeightClass()
        {
            return m_weightClass;
        }

        private void OnEnable()
        {
            m_mainGFX.SetActive(true);
            m_mainGFXCollider.enabled = true;
            m_carryGFX.SetActive(false);
            m_carryGFXCollider.enabled = false;
        }

        public override void AttemptInteract(Player _interactor)
        {
            base.AttemptInteract(_interactor);
            _interactor.GetCarrySystem().SetCurrentValuable(this);
            m_mainGFX.SetActive(false);
            m_mainGFXCollider.enabled = false;
            m_carryGFX.SetActive(true);
            m_carryGFXCollider.enabled = true;
        }
    }
}
