using System;
using System.IO;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;

    private string userName;
    private string lastBestScore;

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

    public void StoreLastBestScore(string bestScore)
    {
        Instance.lastBestScore = bestScore;
    }

    public string GetUserName() => userName;
    public string GetLastBestScore() => lastBestScore;

    [Serializable]
    class SaveData
    {
        public string UserName;
        public string LastBestScore;
    }

    public void SaveDataToStorage()
    {
        SaveData data = new SaveData();
        data.UserName = userName;
        data.LastBestScore = lastBestScore;

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
        }
    }
}
