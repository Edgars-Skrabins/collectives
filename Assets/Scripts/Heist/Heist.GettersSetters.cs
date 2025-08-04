using Collectives.GlobalConstants;
using Collectives.ScriptableObjects;

namespace Collectives.HeistSystems
{
    public partial class Heist
    {
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