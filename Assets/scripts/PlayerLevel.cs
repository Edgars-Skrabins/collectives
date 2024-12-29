using Collectives.Utilities;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int m_currentLevel;
    private int m_currentExperience;

    [SerializeField] private AnimationCurve m_experienceRequirementCurve;

    private void Start()
    {
        AddExperience(1500);
    }

    private int GetRequirementOfLevel(int _level)
    {
        float experienceRequirement = m_experienceRequirementCurve.Evaluate(_level);
        return (int)experienceRequirement * _level;
    }

    private void SaveLevelAndExperienceData()
    {
        PlayerData playerData = SaveUtility.GetSavedPlayerData();
        playerData.level = m_currentLevel;
        playerData.experience = m_currentExperience;
        SaveUtility.SavePlayerData(playerData);
    }

    public int GetMaxLevel()
    {
        return (int)m_experienceRequirementCurve.keys[m_experienceRequirementCurve.length - 1].time;
    }

    public int GetCurrentLevelAdjusted()
    {
        return m_currentLevel + 1;
    }

    public int GetCurrentExperience()
    {
        return m_currentExperience;
    }

    public void AddExperience(int _experience)
    {
        m_currentExperience += _experience;

        if (m_currentLevel == GetMaxLevel())
        {
            return;
        }

        for (int i = m_currentLevel + 1; i < GetMaxLevel(); i++)
        {
            if (GetRequirementOfLevel(i) <= m_currentExperience)
            {
                m_currentLevel = i;
                continue;
            }

            break;
        }

        SaveLevelAndExperienceData();
    }

#if UNITY_EDITOR
    [ContextMenu("Log all level requirements")]
    private void LogAllLevelRequirements()
    {
        Debug.Log("--- LOGGING ALL LEVEL REQUIREMENTS ---");
        for (int i = 1; i < GetMaxLevel(); i++)
        {
            Debug.Log("Level " + i + " Requirement: " + GetRequirementOfLevel(i));
        }
        Debug.Log("--- END OF LOG ---");
    }
#endif
}
