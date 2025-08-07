using System.Collections.ObjectModel;
using Collectives.GlobalConstants;
using Collectives.ValuableSystems;

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

        public void SetElapsedTime(float _elapsedTime)
        {
            m_elapsedTime = _elapsedTime;
        }

        public ObservableCollection<IValuable> GetCollectedValuablesCopy()
        {
            return new ObservableCollection<IValuable>(m_collectedValuables);
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