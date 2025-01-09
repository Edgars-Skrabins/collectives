using Collectives.HeistSystems;
using Collectives.Utilities.Constants;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collectives
{
    public class ConditionallyBasedItemSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectSpawnSettingSO m_spawnSetting;

        private void Start()
        {
            EnableObjectIfPassesSpawnCheck();
        }

        private void EnableObjectIfPassesSpawnCheck()
        {
            int spawnRate = GetCurrentDifficultySpawnRate();
            bool isOutOfSpawnChanceRange = Random.Range(0, 100) > spawnRate;
            if (isOutOfSpawnChanceRange)
            {
                gameObject.SetActive(false);
            }
        }

        private int GetCurrentDifficultySpawnRate()
        {
            EHeistDifficulty heistDifficulty = Heist.I.GetStaticHeistData().difficulty;
            ObjectSpawnSettingSO.SpawnRate currentDifficultySpawnSetting = m_spawnSetting.spawnRates.Find(
                setting => setting.difficulty == heistDifficulty);
            return currentDifficultySpawnSetting.spawnRatePercentage;
        }
    }
}
