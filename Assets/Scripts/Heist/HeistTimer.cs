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

        private void CountElapsedTime()
        {
            m_elapsedTime += Time.deltaTime;
        }

        private void HandleTimerUpdatedEvent()
        {
            if (m_elapsedTime % 1f < Time.deltaTime)
            {
                OnTimerUpdated?.Invoke(m_elapsedTime.ToTimeFormat());
            }
        }
    }
}