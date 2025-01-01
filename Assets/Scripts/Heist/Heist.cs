using Collectives.Utilities;
using Collectives.Utilities.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Collectives.HeistSystems
{
    public struct DynamicHeistData
    {
        public int accquiredMoney;
        public int accquiredExperience;
        public int amountOfCollectedValuables;
        public int amountOfRequiredCollectedValuables;
    }

    public struct StaticHeistData
    {
        public string heistName;
        public string heistDescription;
    }

    public class Heist : Singleton<Heist>
    {
        [SerializeField] private EGameScenes m_endGameScene;
        [SerializeField] private int m_amountOfValuablesRequired;

        private StaticHeistData m_staticHeistData;
        private DynamicHeistData m_dynamicHeistData;

        protected override void Awake()
        {
            base.Awake();
            InitializeStaticHeistData();
        }

        private void InitializeStaticHeistData()
        {
            // Get the settings that the player has selected for this heist.
            // At the time of writing this, difficulty and heist name was planned.
            // Delete these comments when implementation is done.
            StaticHeistData dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist = new StaticHeistData
            {
                heistName = "Test Heist",
                heistDescription = "Test Heist Description",
            };

            m_staticHeistData = dataTakenFromTheUIMenuWhenPlayerClicksPlayOnThisHeist;
        }

        public StaticHeistData GetStaticHeistData()
        {
            return m_staticHeistData;
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
    }
}
