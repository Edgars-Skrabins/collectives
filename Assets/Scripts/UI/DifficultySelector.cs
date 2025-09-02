using Collectives.GlobalConstants;
using UnityEngine;

namespace Collectives.UI
{
    public class DifficultySelector : MonoBehaviour
    {
        public void OnDropdownValueChanged(int _index)
        {
            PersistentDataManager.m_CurrentSelectedDifficulty = (EHeistDifficulty)_index;
        }
    }
}