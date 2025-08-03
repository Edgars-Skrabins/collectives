using System.Collections.Generic;
using Collectives.GlobalConstants;
using Collectives.ScriptableObjects;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public partial class Heist
    {
        private HeistDataSO m_heistDataSO;
        private DynamicHeistData m_dynamicHeistData = new DynamicHeistData(new List<Valuable>());
        private EHeistDifficulty m_heistDifficulty;
        private EHeistTacticState m_currentTacticState;

        public HeistDataSO GetHeistData()
        {
            return m_heistDataSO;
        }

        public DynamicHeistData GetDynamicData()
        {
            return m_dynamicHeistData;
        }

        public EHeistDifficulty GetDifficulty()
        {
            return m_heistDifficulty;
        }

        public EHeistTacticState GetCurrentTacticState()
        {
            return m_currentTacticState;
        }
    }
}