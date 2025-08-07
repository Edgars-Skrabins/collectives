using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public partial class DynamicHeistData : IDisposable
    {
        private int m_acquiredMoney;
        private int m_acquiredExperience;
        private int m_requiredMoney;
        private float m_elapsedTime;
        private readonly ObservableCollection<IValuable> m_collectedValuables = new();
        private readonly int[] m_mustHaveValuableIDs;
        private EHeistTacticState m_currentTacticState;

        private bool m_hasHeistRequirementsMet;
        private bool m_hasCollectedMustHaveValuables;

        public DynamicHeistData(EHeistTacticState _startingTacticState, int mRequiredMoney, int[] mMustHaveValuableIDs)
        {
            m_currentTacticState = _startingTacticState;
            m_requiredMoney = mRequiredMoney;
            m_mustHaveValuableIDs = mMustHaveValuableIDs;

            m_collectedValuables.CollectionChanged += UpdateHeistRequirementStatus;
        }

        public void AddValuableToCollected(IValuable _valuable)
        {
            m_collectedValuables.Add(_valuable);
            m_acquiredMoney += _valuable.GetValuableData().monetaryValue;
            m_acquiredExperience += _valuable.GetValuableData().experienceValue;
        }

        public bool HasCollectedRequiredAmountOfMoney()
        {
            return m_acquiredMoney >= m_requiredMoney;
        }

        public bool HasCollectedMustHaveValuables()
        {
            if (m_hasCollectedMustHaveValuables)
            {
                return true;
            }

            bool hasCollectedMustHaveValuables = m_mustHaveValuableIDs.Length <= 0 || m_mustHaveValuableIDs.All(id =>
                m_collectedValuables.Any(valuable => valuable.GetID() == id)
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
            m_collectedValuables.CollectionChanged -= UpdateHeistRequirementStatus;
        }

        ~DynamicHeistData()
        {
            Dispose();
        }
    }
}