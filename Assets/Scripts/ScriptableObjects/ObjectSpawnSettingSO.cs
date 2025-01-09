using System;
using System.Collections;
using System.Collections.Generic;
using Collectives.Utilities.Constants;
using UnityEngine;

namespace Collectives
{
    [CreateAssetMenu(fileName = "ItemSpawnSetting", menuName = "Collectives/ItemSpawnSetting", order = 0)]
    public class ObjectSpawnSettingSO : ScriptableObject
    {
        public string itemName;

        [Serializable]
        public class SpawnRate
        {
            public EHeistDifficulty m_Difficulty;
            [Range(0, 100)]
            public float m_SpawnRatePercentage;
        }

        public List<SpawnRate> m_SpawnRates = new List<SpawnRate>();
    }
}

