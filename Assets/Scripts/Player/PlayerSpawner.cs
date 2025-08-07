using UnityEngine;

namespace Collectives
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject m_playerPrefab;
        [SerializeField] private Transform[] m_spawnPositions;

        private void Start()
        {
            SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            Instantiate(m_playerPrefab, m_spawnPositions[0].position, m_spawnPositions[0].rotation);
        }
    }
}