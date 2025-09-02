using System;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.HeistSystems.DropOffZone;
using Collectives.ScriptableObjects;
using Collectives.Utilities;
using Collectives.ValuableSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives.HeistSystems
{
    public partial class Heist : Singleton<Heist>
    {
        public event Action<IValuable, DropOffZoneData> OnValuableCollected;
        public UnityEvent OnHeistComplete;
        public UnityEvent OnHeistFail;

        [SerializeField] private HeistDataSO m_heistDataSO;
        [SerializeField] private HeistTimer m_heistTimerCS;
        [SerializeField] private float m_delayBeforeHeistFailSceneLoad;
        [SerializeField] private float m_delayBeforeHeistSucceedsSceneLoad;
        [SerializeField] private EGameScenes m_heistSuccessScene;
        [SerializeField] private EGameScenes m_heistFailScene;

        private EHeistDifficulty m_heistDifficulty;
        private DynamicHeistData m_dynamicHeistData;

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
            int requiredMoney = m_heistDataSO.moneyRequiredPerDifficulty.First(obj => obj.difficulty == m_heistDifficulty)
                .moneyRequired;
            m_dynamicHeistData = new DynamicHeistData(GetStartingTacticState(), requiredMoney, m_heistDataSO.mustHaveValuableIDs);
        }

        private EHeistTacticState GetStartingTacticState()
        {
            return m_heistDataSO.tacticRules == EHeistTacticRules.LOUD_ONLY ? EHeistTacticState.LOUD : EHeistTacticState.STEALTH;
        }

        public void AddValuableToCollected(IValuable _valuable, DropOffZoneData _dropOffZoneData)
        {
            m_dynamicHeistData.AddValuableToCollected(_valuable);
            OnValuableCollected?.Invoke(_valuable, _dropOffZoneData);
        }

        private void SetCurrentTacticState(EHeistTacticState _newTacticState)
        {
            m_dynamicHeistData.SetCurrentTacticState(_newTacticState);
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
            m_dynamicHeistData.SetElapsedTime(HeistTimer.I.GetElapsedSeconds());
        }
    }
}