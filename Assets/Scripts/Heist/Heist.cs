using System;
using System.Collections.Generic;
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
    public class Heist : Singleton<Heist>
    {
        public UnityEvent OnHeistComplete;
        public UnityEvent OnHeistFail;

        public event Action<IValuable, DropOffZoneData> OnValuableCollected;

        [SerializeField] private HeistTimer m_heistTimerCS;
        [SerializeField] private float m_delayBeforeHeistFailSceneLoad;
        [SerializeField] private EGameScenes m_heistSuccessScene;
        [SerializeField] private EGameScenes m_heistFailScene;

        private EHeistTacticState m_currentTacticState;
        private HeistDataSO m_heistDataSO;
        private DynamicHeistData m_dynamicHeistData = new DynamicHeistData(new List<Valuable>());

        public HeistDataSO GetData()
        {
            return m_heistDataSO;
        }

        public DynamicHeistData GetDynamicData()
        {
            return m_dynamicHeistData;
        }

        public EHeistDifficulty GetDifficulty()
        {
            // TODO: Marking this for implementing difficulty selection in the future.
            return EHeistDifficulty.EASY;
        }

        public void AddValuableToCollected(IValuable _valuable, DropOffZoneData _dropOffZoneData)

        {
            m_dynamicHeistData.collectedValuables.Add(_valuable);
            m_dynamicHeistData.acquiredMoney += _valuable.GetValuableData().monetaryValue;
            m_dynamicHeistData.acquiredExperience += _valuable.GetValuableData().experienceValue;

            OnValuableCollected?.Invoke(_valuable, _dropOffZoneData);

            if (!m_dynamicHeistData.heistRequirementsMet)
            {
                UpdateHeistRequirementsStatus();
            }
        }

        public EHeistTacticState GetCurrentTacticState()
        {
            return m_currentTacticState;
        }

        private void SetCurrentTacticState(EHeistTacticState _newTacticState)
        {
            m_currentTacticState = _newTacticState;
            bool heistIsStealthOnly = m_heistDataSO.tacticRules == EHeistTacticRules.STEALTH_ONLY;

            if (_newTacticState == EHeistTacticState.LOUD && heistIsStealthOnly)
            {
                FailHeist();
            }
        }

        public void FailHeist()
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
            SceneNavigation.GoToHeistSuccessScene();
            OnHeistComplete?.Invoke();
        }

        private void UpdateElapsedTime()
        {
            m_dynamicHeistData.elapsedTime = HeistTimer.I.GetElapsedSeconds();
        }

        private void UpdateHeistRequirementsStatus()
        {
            bool hasCollectedRequiredAmount = m_dynamicHeistData.collectedValuables.Count >= m_heistDataSO.amountOfValuablesRequired;
            bool hasCollectedMustHaveValuables = HasCollectedMustHaveValuables();

            if (hasCollectedRequiredAmount && hasCollectedMustHaveValuables)
            {
                m_dynamicHeistData.heistRequirementsMet = true;
            }
        }

        private bool HasCollectedMustHaveValuables()
        {
            if (m_heistDataSO.mustHaveValuableIDs.Length <= 0)
            {
                return true;
            }

            return m_heistDataSO.mustHaveValuableIDs.All(id => m_dynamicHeistData.collectedValuables.Any(valuable => valuable.GetID() == id)
            );
        }
    }
}