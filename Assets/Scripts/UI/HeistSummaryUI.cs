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
            StaticHeistData staticHeistData = Heist.I.GetStaticHeistData();
            DynamicHeistData dynamicHeistData = Heist.I.GetDynamicHeistData();

            m_heistName.text = staticHeistData.name;
            m_heistDescription.text = staticHeistData.description;
            m_timeElapsed.text = Heist.I.GetFormattedHeistTime();
            m_stolenValuableAmount.text = dynamicHeistData.collectedValuables.Count.ToString();
            m_moneyEarned.text = dynamicHeistData.acquiredMoney.ToString();
            m_earnedExperience.text = dynamicHeistData.acquiredExperience.ToString();
        }
    }
}