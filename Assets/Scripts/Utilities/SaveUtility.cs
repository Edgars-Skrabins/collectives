using UnityEngine;

namespace Collectives.Utilities
{
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
        private struct PlayerPrefsKeys
        {
            public const string PLAYER_DATA = "PLAYER_DATA";
        }

        public static void SavePlayerData(PlayerData _playerData)
        {
            string dataJson = JsonUtility.ToJson(_playerData);
            dataJson = Base64Utility.GetBase64EncodedString(dataJson);
            PlayerPrefs.SetString(PlayerPrefsKeys.PLAYER_DATA, dataJson);
        }

        public static PlayerData GetSavedPlayerData()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsKeys.PLAYER_DATA))
            {
                return new PlayerData(0, 0);
            }
            string dataJson = PlayerPrefs.GetString(PlayerPrefsKeys.PLAYER_DATA);
            dataJson = Base64Utility.GetBase64DecodedString(dataJson);
            return JsonUtility.FromJson<PlayerData>(dataJson);
        }
    }
}
