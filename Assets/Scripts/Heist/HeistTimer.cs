using Collectives.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Collectives.HeistSystems
{
    public class HeistTimer : Singleton<HeistTimer>
    {
        public UnityEvent<string> OnTimerUpdated;
        private float m_elapsedTime;
        private bool m_isTimerPaused;

        private void Update()
        {
            if (m_isTimerPaused)
            {
                return;
            }
            CountElapsedTime();
            HandleTimerUpdatedEvent();
        }

        public void StopTimer()
        {
            m_isTimerPaused = true;
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
    }
}