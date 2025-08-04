using System.Collections.Generic;
using Collectives.GlobalConstants;
using Collectives.ValuableSystems;

namespace Collectives.HeistSystems
{
    public class DynamicHeistData
    {
        public bool heistRequirementsMet = false;
        public int acquiredMoney = 0;
        public int acquiredExperience = 0;
        public float elapsedTime = 0f;
        public readonly List<IValuable> collectedValuables = new();
        public EHeistTacticState currentTacticState;
    }
}