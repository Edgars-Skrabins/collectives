using System;
using System.Linq;
using Collectives.GlobalConstants;
using Collectives.HeistSystems;
using Collectives.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collectives.ObjectSystems
{
    public class ConditionallyBasedItemSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectSpawnSettingSO m_spawnSetting;
        [SerializeField] private Transform[] m_possibleSpawnLocations;

        private void Start()
        {
            gameObject.SetActive(false);
            EnableObjectIfPassesSpawnCheck();
        }

        private void EnableObjectIfPassesSpawnCheck()
        {
            int spawnRate = GetCurrentDifficultySpawnRate();
            bool isOutOfSpawnChanceRange = Random.Range(0, 100) > spawnRate;
            if (isOutOfSpawnChanceRange)
            {
                EnableObjectAtSpawnLocation();
            }
        }

        private void EnableObjectAtSpawnLocation()
        {
            if (m_possibleSpawnLocations.Length > 1)
            {
                MoveObjectToSpawnLocation();
            }

            gameObject.SetActive(true);
        }

        private void MoveObjectToSpawnLocation()
        {
            int randomIndex = Random.Range(0, m_possibleSpawnLocations.Length);
            Transform spawnTF = m_possibleSpawnLocations[randomIndex];
            transform.position = spawnTF.position;
            transform.rotation = spawnTF.rotation;
        }

        private int GetCurrentDifficultySpawnRate()
        {
            EHeistDifficulty heistDifficulty = Heist.I.GetDifficulty();
            ObjectSpawnSettingSO.SpawnRate currentDifficultySpawnSetting =
                m_spawnSetting.spawnRates.FirstOrDefault(setting => setting.difficulty == heistDifficulty);

            if (currentDifficultySpawnSetting == null)
            {
                Debug.LogError("No spawn rate found for difficulty " + heistDifficulty);
                throw new NullReferenceException();
            }

            return currentDifficultySpawnSetting.spawnRatePercentage;
        }
    }
}