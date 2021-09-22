using System;
using System.IO;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;

    private string userName;
    private string lastBestScoreUserName;
    private int lastBestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSavedData();
    }

    public void StoreUserNameForPersistence(string name)
    {
        Instance.userName = name;
    }

    public void StoreLastBestScore(int bestScore, string userName)
    {
        Instance.lastBestScore = bestScore;
        Instance.lastBestScoreUserName = userName;
    }

    public string GetUserName() => userName;
    public int GetLastBestScore() => lastBestScore;
    public string GetLastBestScoreUserName() => lastBestScoreUserName;

    [Serializable]
    class SaveData
    {
        public string UserName;
        public int LastBestScore;
        public string LastBestScoreUserName;
    }

    public void SaveDataToStorage()
    {
        SaveData data = new SaveData();
        data.UserName = userName;
        data.LastBestScore = lastBestScore;
        data.LastBestScoreUserName = lastBestScoreUserName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.UserName;
            lastBestScore = data.LastBestScore;
            lastBestScoreUserName = data.LastBestScoreUserName;
        }
    }
}
