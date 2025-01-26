using System.Collections.Generic;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.ScriptableObjects;
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
        [SerializeField] private EGameScenes m_heistSuccessScene;
        [SerializeField] private EGameScenes m_heistFailScene;

        private HeistDataSO m_heistDataSO;
        private DynamicHeistData m_dynamicHeistData = new DynamicHeistData(new List<Valuable>());

        public string GetFormattedHeistTime()
        {
            return m_heistTimerCS.GetFormattedElapsedTime();
        }

        public HeistDataSO GetHeistData()
        {
            return m_heistDataSO;
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
                CheckHeistRequirements();
            }
        }

        public void LoadHeistSuccessScene()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene((int)m_heistSuccessScene);
        }

        public void LoadHeistFailScene()
        {
        }

        public void ExitHeistSuccessScene()
        {
            Destroy(gameObject);
        }

        private void CheckHeistRequirements()
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

            return m_heistDataSO.mustHaveValuableIDs.All(
                id =>
                    m_dynamicHeistData.collectedValuables.Any(valuable => valuable.GetID() == id)
            );
        }
    }
}