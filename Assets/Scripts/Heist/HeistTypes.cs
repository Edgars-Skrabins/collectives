using System;
using System.Collections.Generic;
using Collectives.Valuable;

namespace Collectives.HeistSystems
{
    public struct DynamicHeistData
    {
        public bool heistRequirementsMet;
        public int acquiredMoney;
        public int acquiredExperience;
        public readonly List<ValuableData> collectedValuables;

        public DynamicHeistData(List<ValuableData> _collectedValuables)
        {
            heistRequirementsMet = false;
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

    [Serializable]
    public class HeistEvent
    {
    }
}
