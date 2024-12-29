using UnityEngine;

namespace Collectives.Utilities
{
    public enum EPlayerPrefs
    {
        PLAYER_DATA,
    }

    public struct PlayerData
    {
        public int level;
        public int experience;

        public PlayerData(int _level, int _experience)
        {
            level = _level;
            experience = _experience;
        }
    }

    public static class SaveUtility
    {
        public static void SavePlayerData(PlayerData _playerData)
        {
            string json = JsonUtility.ToJson(_playerData);
            json = Base64Utility.GetBase64EncodedString(json);
            PlayerPrefs.SetString(EPlayerPrefs.PLAYER_DATA.ToString(), json);
        }

        public static PlayerData GetSavedPlayerData()
        {
            string json = PlayerPrefs.GetString(EPlayerPrefs.PLAYER_DATA.ToString());
            json = Base64Utility.GetBase64DecodedString(json);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
