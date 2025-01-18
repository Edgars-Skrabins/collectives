using System;
using System.Collections.Generic;
using Collectives.GlobalConstants;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public struct DynamicHeistData
    {
        public bool heistRequirementsMet;
        public int acquiredMoney;
        public int acquiredExperience;
        public readonly List<Valuable> collectedValuables;

        public DynamicHeistData(List<Valuable> _collectedValuables)
        {
            heistRequirementsMet = false;
            acquiredMoney = 0;
            acquiredExperience = 0;
            collectedValuables = new List<Valuable>();
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