using UnityEngine;

namespace Collectives.HeistSystems
{
    public class HeistTimer : MonoBehaviour
    {
        private float m_elapsedTime;

        private void Update()
        {
            CountElapsedTime();
        }

        private void CountElapsedTime()
        {
            m_elapsedTime += Time.deltaTime;
        }

        public int GetElapsedSeconds()
        {
            Debug.Log("Seconds:" + (int)m_elapsedTime);
            return (int)m_elapsedTime;
        }

        public string GetFormattedElapsedTime()
        {
            int hours = (int)m_elapsedTime / 3600;
            int minutes = (int)m_elapsedTime / 60;
            int seconds = (int)m_elapsedTime % 60;
            Debug.Log($"{hours:00}:{minutes:00}:{seconds:00}");
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}
