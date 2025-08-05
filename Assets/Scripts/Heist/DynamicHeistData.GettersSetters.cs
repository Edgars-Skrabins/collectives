using Collectives.GlobalConstants;

namespace Collectives.HeistSystems
{
    public partial class DynamicHeistData
    {
        public int GetAcquiredMoney()
        {
            return m_acquiredMoney;
        }

        public int GetAcquiredExperience()
        {
            return m_acquiredExperience;
        }

        public int GetRequiredMoney()
        {
            return m_requiredMoney;
        }

        public void SetRequiredMoney(int _requiredMoney)
        {
            m_requiredMoney = _requiredMoney;
        }

        public float GetElapsedTime()
        {
            return m_elapsedTime;
        }

        public float SetElapsedTime(float _elapsedTime)
        {
            return m_elapsedTime = _elapsedTime;
        }

        public EHeistTacticState GetCurrentTacticState()
        {
            return m_currentTacticState;
        }

        public void SetCurrentTacticState(EHeistTacticState _newTacticState)
        {
            m_currentTacticState = _newTacticState;
        }

        public bool GetHasHeistRequirementsMet()
        {
            return m_hasHeistRequirementsMet;
        }
    }
}