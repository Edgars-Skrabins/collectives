using System;
using Collectives.GlobalConstants;
using UnityEngine;

namespace Collectives.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemSpawnSetting", menuName = "Collectives/ItemSpawnSetting", order = 0)]
    public class ObjectSpawnSettingSO : ScriptableObject
    {
        [Serializable]
        public class SpawnRate
        {
            public EHeistDifficulty difficulty;
            [Range(0, 100)]
            public int spawnRatePercentage;
        }

        public SpawnRate[] spawnRates;
    }
}