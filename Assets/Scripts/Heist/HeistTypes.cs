using System.Collections.Generic;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public struct DynamicHeistData
    {
        public bool heistRequirementsMet;
        public int acquiredMoney;
        public int acquiredExperience;
        public float elapsedTime;
        public readonly List<IValuable> collectedValuables;

        public DynamicHeistData(List<Valuable> _collectedValuables)
        {
            heistRequirementsMet = false;
            acquiredMoney = 0;
            acquiredExperience = 0;
            elapsedTime = 0f;
            collectedValuables = new List<IValuable>();
        }
    }
}