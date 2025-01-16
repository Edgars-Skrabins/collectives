using UnityEngine;
using UnityEngine.Events;

namespace Collectives.HeistSystems
{
    public class HeistTimer : MonoBehaviour
    {
        private float m_elapsedTime;
        public UnityEvent<string> OnTimerUpdated;

        private void Update()
        {
            CountElapsedTime();
            HandleTimerUpdatedEvent();
        }

        private void CountElapsedTime()
        {
            m_elapsedTime += Time.deltaTime;
        }

        private void HandleTimerUpdatedEvent()
        {
            if (m_elapsedTime % 1f < Time.deltaTime)
            {
                OnTimerUpdated?.Invoke(GetFormattedElapsedTime());
            }
        }

        public int GetElapsedSeconds()
        {
            return (int)m_elapsedTime;
        }

        public string GetFormattedElapsedTime()
        {
            int hours = (int)m_elapsedTime / 3600;
            int minutes = (int)m_elapsedTime / 60 % 60;
            int seconds = (int)m_elapsedTime % 60;
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}
