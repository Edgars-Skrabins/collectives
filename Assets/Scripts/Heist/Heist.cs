using System.Collections.Generic;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.Utilities;
using Collectives.ValuableSystems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Collectives.HeistSystems
{
    public class Heist : Singleton<Heist>
    {
        public UnityEvent OnHeistComplete;
        public UnityEvent OnHeistFail;

        [SerializeField] private HeistTimer m_heistTimerCS;

        private StaticHeistData m_staticHeistData;
        private DynamicHeistData m_dynamicHeistData = new DynamicHeistData(new List<Valuable>());

        protected override void Awake()
        {
            base.Awake();
            InitializeStaticHeistData();
        }

        private void InitializeStaticHeistData()
        {
            // Get the settings that the player has selected for this heist.
            StaticHeistData dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist = new StaticHeistData
            {
                name = "Test Heist",
                description = "Test Heist Description",
                amountOfValuablesRequired = 6,
                mustHaveValuableIDs = new[] {55, 999},
            };

            m_staticHeistData = dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist;
        }

        public string GetFormattedHeistTime()
        {
            return m_heistTimerCS.GetFormattedElapsedTime();
        }

        public StaticHeistData GetStaticHeistData()
        {
            return m_staticHeistData;
        }

        public DynamicHeistData GetDynamicHeistData()
        {
            return m_dynamicHeistData;
        }

        public void AddValuableToDropOff(Valuable _valuable)
        {
            m_dynamicHeistData.collectedValuables.Add(_valuable);
            m_dynamicHeistData.acquiredMoney += _valuable.GetValuableData().monetaryValue;
            m_dynamicHeistData.acquiredExperience += _valuable.GetValuableData().experienceValue;

            if (!m_dynamicHeistData.heistRequirementsMet)
            {
                UpdateHeistRequirementsStatus();
            }
        }

        public void LoadHeistSuccessScene()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene((int)EGameScenes.HEIST_SUCCESS);
        }

        public void LoadHeistFailScene()
        {
        }

        public void ExitHeistSuccessScene()
        {
            Destroy(gameObject);
        }

        private void UpdateHeistRequirementsStatus()
        {
            bool hasCollectedRequiredAmount = m_dynamicHeistData.collectedValuables.Count >= m_staticHeistData.amountOfValuablesRequired;
            bool hasCollectedMustHaveValuables = HasCollectedMustHaveValuables();

            if (hasCollectedRequiredAmount && hasCollectedMustHaveValuables)
            {
                m_dynamicHeistData.heistRequirementsMet = true;
            }
        }

        private bool HasCollectedMustHaveValuables()
        {
            if (m_staticHeistData.mustHaveValuableIDs.Length <= 0)
            {
                return true;
            }

            return m_staticHeistData.mustHaveValuableIDs.All(
                id =>
                    m_dynamicHeistData.collectedValuables.Any(valuable => valuable.GetID() == id)
            );
        }
    }
}