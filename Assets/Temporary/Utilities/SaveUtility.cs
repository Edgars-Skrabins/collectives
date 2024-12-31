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
            string dataJson = JsonUtility.ToJson(_playerData);
            dataJson = Base64Utility.GetBase64EncodedString(dataJson);
            PlayerPrefs.SetString(EPlayerPrefs.PLAYER_DATA.ToString(), dataJson);
        }

        public static PlayerData GetSavedPlayerData()
        {
            if (!PlayerPrefs.HasKey(EPlayerPrefs.PLAYER_DATA.ToString()))
            {
                return new PlayerData(0, 0);
            }
            string dataJson = PlayerPrefs.GetString(EPlayerPrefs.PLAYER_DATA.ToString());
            dataJson = Base64Utility.GetBase64DecodedString(dataJson);
            return JsonUtility.FromJson<PlayerData>(dataJson);
        }
    }
}
