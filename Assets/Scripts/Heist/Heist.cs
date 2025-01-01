using System.Collections.Generic;
using System.Linq;
using Collectives.Utilities;
using Collectives.Utilities.Constants;
using Collectives.Valuable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Collectives.HeistSystems
{
    public struct DynamicHeistData
    {
        public int acquiredMoney;
        public int acquiredExperience;
        public readonly List<ValuableData> collectedValuables;

        public DynamicHeistData(List<ValuableData> _collectedValuables)
        {
            acquiredMoney = 0;
            acquiredExperience = 0;
            collectedValuables = new List<ValuableData>();
        }
    }

    public struct StaticHeistData
    {
        public string heistName;
        public string heistDescription;
        public int amountOfValuablesRequired;
        public int[] mustHaveValuableIDs;

        public StaticHeistData(int[] mustHaveValuableIDs)
        {
            heistName = "";
            heistDescription = "";
            amountOfValuablesRequired = 0;
            this.mustHaveValuableIDs = mustHaveValuableIDs;
        }
    }

    public class Heist : Singleton<Heist>
    {
        [SerializeField] private EGameScenes m_endGameScene;

        private StaticHeistData m_staticHeistData;
        private DynamicHeistData m_dynamicHeistData = new DynamicHeistData(
            new List<ValuableData>());
        private bool m_heistRequirementsMet;

        protected override void Awake()
        {
            base.Awake();
            InitializeStaticHeistData();
            InitializeDynamicHeistData();
        }

        private void InitializeDynamicHeistData()
        {
            m_dynamicHeistData = new DynamicHeistData();
        }

        private void InitializeStaticHeistData()
        {
            // Get the settings that the player has selected for this heist.
            StaticHeistData dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist = new StaticHeistData
            {
                heistName = "Test Heist",
                heistDescription = "Test Heist Description",
                amountOfValuablesRequired = 6,
                mustHaveValuableIDs = new[] {55, 999},
            };

            m_staticHeistData = dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist;
        }

        public StaticHeistData GetStaticHeistData()
        {
            return m_staticHeistData;
        }

        public void AddValuableToDropOff(ValuableData _valuable)
        {
            m_dynamicHeistData.collectedValuables.Add(_valuable);
            if (!m_heistRequirementsMet)
            {
                CheckHeistRequirements();
            }
        }

        public bool GetHeistRequirementsMet()
        {
            return m_heistRequirementsMet;
        }

        public void LoadEndGameScene()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene((int)m_endGameScene);
        }

        public void ExitEndGameScene()
        {
            Destroy(gameObject);
        }

        private void CheckHeistRequirements()
        {
            bool hasCollectedRequiredAmount = m_dynamicHeistData.collectedValuables.Count >= m_staticHeistData.amountOfValuablesRequired;
            bool hasCollectedMustHaveValuables = HasCollectedMustHaveValuables();

            if (hasCollectedRequiredAmount && hasCollectedMustHaveValuables)
            {
                m_heistRequirementsMet = true;
            }
        }

        private bool HasCollectedMustHaveValuables()
        {
            if (m_staticHeistData.mustHaveValuableIDs.Length <= 0)
            {
                return true;
            }

            return m_staticHeistData.mustHaveValuableIDs.All(id =>
                m_dynamicHeistData.collectedValuables.Any(valuable => valuable.id == id));
        }
    }
}
