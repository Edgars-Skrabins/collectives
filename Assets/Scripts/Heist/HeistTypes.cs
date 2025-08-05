using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public class DynamicHeistData : IDisposable
    {
        private int acquiredMoney;
        private int acquiredExperience;
        private int requiredMoney;
        private float elapsedTime;
        private readonly ObservableCollection<IValuable> collectedValuables = new();
        private readonly int[] mustHaveValuableIDs;
        private EHeistTacticState currentTacticState;

        private bool m_hasHeistRequirementsMet;
        private bool m_hasCollectedMustHaveValuables;

        public DynamicHeistData(EHeistTacticState _startingTacticState, int _requiredMoney, int[] _mustHaveValuableIDs)
        {
            currentTacticState = _startingTacticState;
            requiredMoney = _requiredMoney;
            mustHaveValuableIDs = _mustHaveValuableIDs;

            collectedValuables.CollectionChanged += UpdateHeistRequirementStatus;
        }

        public int GetAcquiredMoney()
        {
            return acquiredMoney;
        }

        public int GetAcquiredExperience()
        {
            return acquiredExperience;
        }

        public int GetRequiredMoney()
        {
            return requiredMoney;
        }

        public void SetRequiredMoney(int _requiredMoney)
        {
            requiredMoney = _requiredMoney;
        }

        public float GetElapsedTime()
        {
            return elapsedTime;
        }

        public float SetElapsedTime(float _elapsedTime)
        {
            return elapsedTime = _elapsedTime;
        }

        public void AddValuableToCollected(IValuable _valuable)
        {
            collectedValuables.Add(_valuable);
            acquiredMoney += _valuable.GetValuableData().monetaryValue;
            acquiredExperience += _valuable.GetValuableData().experienceValue;
        }

        public EHeistTacticState GetCurrentTacticState()
        {
            return currentTacticState;
        }

        public void SetCurrentTacticState(EHeistTacticState _newTacticState)
        {
            currentTacticState = _newTacticState;
        }

        public bool GetHasHeistRequirementsMet()
        {
            return m_hasHeistRequirementsMet;
        }

        public bool HasCollectedRequiredAmountOfMoney()
        {
            return acquiredMoney >= requiredMoney;
        }

        public bool HasCollectedMustHaveValuables()
        {
            if (m_hasCollectedMustHaveValuables)
            {
                return true;
            }

            bool hasCollectedMustHaveValuables = mustHaveValuableIDs.Length <= 0 || mustHaveValuableIDs.All(id =>
                collectedValuables.Any(valuable => valuable.GetID() == id)
            );

            if (hasCollectedMustHaveValuables)
            {
                m_hasCollectedMustHaveValuables = true;
                return true;
            }

            return false;
        }


        private void UpdateHeistRequirementStatus(object obj, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (m_hasHeistRequirementsMet)
            {
                return;
            }

            m_hasHeistRequirementsMet = HasCollectedRequiredAmountOfMoney() && HasCollectedMustHaveValuables();
        }

        public void Dispose()
        {
            collectedValuables.CollectionChanged -= UpdateHeistRequirementStatus;
        }

        ~DynamicHeistData()
        {
            Dispose();
        }
    }
}