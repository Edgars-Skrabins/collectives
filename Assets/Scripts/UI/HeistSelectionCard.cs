using Collectives.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Collectives.UI
{
    public class HeistSelectionCard : MonoBehaviour
    {
        [SerializeField] private HeistDataSO m_heistData;
        [SerializeField] private TMP_Text m_title;
        [SerializeField] private TMP_Text m_description;
        [SerializeField] private GameObject m_descriptionTextObj;

        private void OnEnable()
        {
            FillUIElementsWithData();
        }

        private void FillUIElementsWithData()
        {
            m_title.text = m_heistData.heistName;
            m_description.text = m_heistData.description;
        }

        public void OnDescriptionButtonPointerEnter()
        {
            m_descriptionTextObj.SetActive(true);
        }

        public void OnDescriptionButtonPointerExit()
        {
            m_descriptionTextObj.SetActive(false);
        }
    }
}