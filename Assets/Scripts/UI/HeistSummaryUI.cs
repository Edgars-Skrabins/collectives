using Collectives.ScriptableObjects;
using Collectives.Utilities;
using TMPro;
using UnityEngine;

namespace Collectives.HeistSystems
{
    public class HeistSummaryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_heistName;
        [SerializeField] private TextMeshProUGUI m_heistDescription;
        [SerializeField] private TextMeshProUGUI m_timeElapsed;
        [SerializeField] private TextMeshProUGUI m_stolenValuableAmount;
        [SerializeField] private TextMeshProUGUI m_moneyEarned;
        [SerializeField] private TextMeshProUGUI m_earnedExperience;

        private void Awake()
        {
            InitializeUIElements();
        }

        private void InitializeUIElements()
        {
            HeistDataSO staticHeistData = Heist.I.GetHeistData();
            DynamicHeistData dynamicHeistData = Heist.I.GetDynamicData();

            m_heistName.text = staticHeistData.name;
            m_heistDescription.text = staticHeistData.description;
            m_timeElapsed.text = dynamicHeistData.GetElapsedTime().ToTimeFormat();
            m_stolenValuableAmount.text = dynamicHeistData.GetCollectedValuablesCopy().Count.ToString();
            m_moneyEarned.text = dynamicHeistData.GetAcquiredMoney().ToString();
            m_earnedExperience.text = dynamicHeistData.GetAcquiredExperience().ToString();
        }
    }
}