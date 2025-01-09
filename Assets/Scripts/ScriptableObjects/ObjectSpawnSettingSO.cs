using System;
using System.Collections.Generic;
using Collectives.Utilities.Constants;
using UnityEngine;

namespace Collectives.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemSpawnSetting", menuName = "Collectives/ItemSpawnSetting", order = 0)]
    public class ObjectSpawnSettingSO : ScriptableObject
    {
        public string itemName;

        [Serializable]
        public class SpawnRate
        {
            public EHeistDifficulty difficulty;
            [Range(0, 100)]
            public int spawnRatePercentage;
        }

        public List<SpawnRate> spawnRates = new List<SpawnRate>();
    }
}
