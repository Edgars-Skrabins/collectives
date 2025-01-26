using System.Collections.Generic;
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
}