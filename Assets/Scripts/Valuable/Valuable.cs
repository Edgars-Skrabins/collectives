using Collectives.DropOffZone;
using Collectives.HeistSystems;
using Collectives.PlayerSystems;
using Collectives.ScriptableObjects;
using UnityEngine;

namespace Collectives.ValuableSystems
{
    public class Valuable : Interactable, IValuable
    {
        [SerializeField] private ValuableDataSO m_valuableData;
        [Space]
        [SerializeField] private GameObject m_mainGFX;
        [SerializeField] private Collider m_mainGFXCollider;
        [Space]
        [SerializeField] private GameObject m_carryGFX;
        [SerializeField] private Collider m_carryGFXCollider;

        public EWeightClasses GetWeightClass()
        {
            return m_valuableData.weightClass;
        }

        private void OnEnable()
        {
            InitializeGFX();
        }

        private void InitializeGFX()
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

        public void Collect(DropOffZoneData _dropOffZoneData)
        {
            Heist.I.AddValuableToCollected(this, _dropOffZoneData);
        }

        public ValuableDataSO GetValuableData()
        {
            return m_valuableData;
        }
    }
}