using Collectives.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Collectives.UI
{
    public class HeistSelectionCard : MonoBehaviour
    {
        [SerializeField] private HeistDataSO m_heistData;
        [SerializeField] private TMP_Text m_titleText;
        [SerializeField] private TMP_Text m_tacticRulesText;
        [SerializeField] private TMP_Text m_descriptionText;
        [SerializeField] private GameObject m_descriptionTextObj;
        [SerializeField] private GameObject m_activeBorder;
        [SerializeField] private GameObject m_inactiveBorder;

        private void OnEnable()
        {
            FillUIElementsWithData();
        }

        private void FillUIElementsWithData()
        {
            m_titleText.text = m_heistData.heistName;
            m_tacticRulesText.text = m_heistData.tacticRules.ToString();
            m_descriptionText.text = m_heistData.description;
        }

        public void OnDescriptionButtonPointerEnter()
        {
            m_descriptionTextObj.SetActive(true);
            m_activeBorder.SetActive(true);
            m_inactiveBorder.SetActive(false);
        }

        public void OnDescriptionButtonPointerExit()
        {
            m_descriptionTextObj.SetActive(false);
            m_activeBorder.SetActive(false);
            m_inactiveBorder.SetActive(true);
        }

        public void OnPlayPress()
        {
            SceneManager.LoadScene(m_heistData.heistScene.ToString());
        }
    }
}