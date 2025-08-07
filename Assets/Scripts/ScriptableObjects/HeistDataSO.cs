using System;
using Collectives.GlobalConstants;
using UnityEngine;

namespace Collectives.ScriptableObjects
{
    [Serializable]
    public class DifficultyMoneyRequirement
    {
        public EHeistDifficulty difficulty;
        public int moneyRequired;
    }

    [CreateAssetMenu(fileName = "HeistData", menuName = "Collectives/HeistData", order = 0)]
    public class HeistDataSO : ScriptableObject
    {
        public string heistName;
        public string description;
        public DifficultyMoneyRequirement[] moneyRequiredPerDifficulty;
        public EHeistTacticRules tacticRules;
        public int[] mustHaveValuableIDs;
    }
}