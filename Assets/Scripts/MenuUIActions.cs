using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIActions : MonoBehaviour
{
    public TMP_InputField userNameInputField;
    public TextMeshProUGUI LastBestScore;

    private void Awake()
    {
        LastBestScore.gameObject.SetActive(false);
        userNameInputField.text = DataHolder.Instance.GetUserName();
    }
    public void StartGame()
    {
        if (userNameInputField.text.Length > 0)
        {
            DataHolder.Instance.StoreUserNameForPersistence(userNameInputField.text);
            DataHolder.Instance.SaveDataToStorage();
            SceneManager.LoadScene(1);
        }
    }

    public void ShowHideLastBestScore()
    {
        int lastBestScore = DataHolder.Instance.GetLastBestScore();
        if (lastBestScore == 0)
        {
            LastBestScore.text = "No scores saved";
        }
        else
        {
            string lastBestScoreUserName = DataHolder.Instance.GetLastBestScoreUserName();
            LastBestScore.text = $"Best score : {lastBestScoreUserName} : {lastBestScore}";
        }
        LastBestScore.gameObject.SetActive(!LastBestScore.gameObject.activeSelf);
    }
}
