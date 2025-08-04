using System;
using System.Linq;
using Collectives.DropOffZone;
using Collectives.GlobalConstants;
using Collectives.ScriptableObjects;
using Collectives.Utilities;
using Collectives.ValuableSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives.HeistSystems
{
    public partial class Heist : Singleton<Heist>
    {
        private readonly DynamicHeistData m_dynamicHeistData = new DynamicHeistData();
        public event Action<IValuable, DropOffZoneData> OnValuableCollected;
        public UnityEvent OnHeistComplete;
        public UnityEvent OnHeistFail;

        [SerializeField] private HeistTimer m_heistTimerCS;
        [SerializeField] private float m_delayBeforeHeistFailSceneLoad;
        [SerializeField] private float m_delayBeforeHeistSucceedsSceneLoad;
        [SerializeField] private EGameScenes m_heistSuccessScene;
        [SerializeField] private EGameScenes m_heistFailScene;

        private HeistDataSO m_heistDataSO;
        private EHeistDifficulty m_heistDifficulty;

        protected override void Awake()
        {
            base.Awake();
            LoadPersistentData();
            InitializeDynamicHeistDataProperties();
        }

        private void LoadPersistentData()
        {
            m_heistDifficulty = PersistentDataManager.m_CurrentSelectedDifficulty;
        }

        private void InitializeDynamicHeistDataProperties()
        {
            m_dynamicHeistData.currentTacticState = GetStartingTacticState();
            m_dynamicHeistData.requiredMoney = m_heistDataSO.moneyRequiredPerDifficulty
                .First(obj => obj.difficulty == m_heistDifficulty).moneyRequired;
        }

        private EHeistTacticState GetStartingTacticState()
        {
            return m_heistDataSO.tacticRules == EHeistTacticRules.LOUD_ONLY ? EHeistTacticState.LOUD : EHeistTacticState.STEALTH;
        }

        public void AddValuableToCollected(IValuable _valuable, DropOffZoneData _dropOffZoneData)
        {
            m_dynamicHeistData.collectedValuables.Add(_valuable);
            m_dynamicHeistData.acquiredMoney += _valuable.GetValuableData().monetaryValue;
            m_dynamicHeistData.acquiredExperience += _valuable.GetValuableData().experienceValue;

            OnValuableCollected?.Invoke(_valuable, _dropOffZoneData);

            if (!m_dynamicHeistData.hasHeistRequirementsMet)
            {
                UpdateHeistRequirementsStatus();
            }
        }

        private void SetCurrentTacticState(EHeistTacticState _newTacticState)
        {
            m_dynamicHeistData.currentTacticState = _newTacticState;
            bool heistIsStealthOnly = m_heistDataSO.tacticRules == EHeistTacticRules.STEALTH_ONLY;

            if (_newTacticState == EHeistTacticState.LOUD && heistIsStealthOnly)
            {
                FailHeist();
            }
        }

        private void FailHeist()
        {
            HeistTimer.I.StopTimer();
            UpdateElapsedTime();
            DontDestroyOnLoad(gameObject);
            Invoke(nameof(SceneNavigation.GoToHeistFailScene), m_delayBeforeHeistFailSceneLoad);
            OnHeistFail?.Invoke();
        }

        private void SucceedHeist()
        {
            HeistTimer.I.StopTimer();
            UpdateElapsedTime();
            DontDestroyOnLoad(gameObject);
            Invoke(nameof(SceneNavigation.GoToHeistSuccessScene), m_delayBeforeHeistSucceedsSceneLoad);
            OnHeistComplete?.Invoke();
        }

        private void UpdateElapsedTime()
        {
            m_dynamicHeistData.elapsedTime = HeistTimer.I.GetElapsedSeconds();
        }

        private void UpdateHeistRequirementsStatus()
        {
            bool hasCollectedRequiredAmount = m_dynamicHeistData.collectedValuables.Count >= m_heistDataSO.mustHaveValuableIDs.Length;

            if (hasCollectedRequiredAmount && HasCollectedMustHaveValuables())
            {
                m_dynamicHeistData.hasHeistRequirementsMet = true;
            }
        }

        private bool HasCollectedMustHaveValuables()
        {
            if (m_heistDataSO.mustHaveValuableIDs.Length <= 0)
            {
                return true;
            }

            return m_heistDataSO.mustHaveValuableIDs.All(id =>
                m_dynamicHeistData.collectedValuables.Any(valuable => valuable.GetID() == id)
            );
        }
    }
}