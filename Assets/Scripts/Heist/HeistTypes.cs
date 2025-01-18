using System;
using System.Collections.Generic;
using Collectives.GlobalConstants;
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
        public string name;
        public string description;
        public EHeistDifficulty difficulty;
        public int amountOfValuablesRequired;
        public int[] mustHaveValuableIDs;

        public StaticHeistData(int[] mustHaveValuableIDs)
        {
            name = "";
            description = "";
            difficulty = EHeistDifficulty.EASY;
            amountOfValuablesRequired = 0;
            this.mustHaveValuableIDs = mustHaveValuableIDs;
        }
    }

    [Serializable]
    public class HeistEvent
    {
    }
}