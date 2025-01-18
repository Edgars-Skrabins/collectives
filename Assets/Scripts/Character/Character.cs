using UnityEngine;

namespace Collectives
{
    public class Character : MonoBehaviour
    {
        private int m_id;

        private void Awake()
        {
            InitializeID();
        }

        private void InitializeID()
        {
            // Get ID from spawner object
        }

        public int GetID()
        {
            return m_id;
        }
    }
}