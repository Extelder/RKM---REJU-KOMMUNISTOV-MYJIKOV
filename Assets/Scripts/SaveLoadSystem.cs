using UnityEngine;

public static class SaveLoadSystem
{
    public static void SaveData(ScriptableObject data, string key)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public static void LoadData(ScriptableObject data, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            JsonUtility.FromJsonOverwrite(json, data);
        }
    }

    public static void ClearData(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}