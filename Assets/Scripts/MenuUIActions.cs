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
        string lastBestScore = DataHolder.Instance.GetLastBestScore();
        if(string.IsNullOrEmpty(lastBestScore))
        {
            lastBestScore = "No scores saved.";
        }
        LastBestScore.text = lastBestScore;
        LastBestScore.gameObject.SetActive(!LastBestScore.gameObject.activeSelf);
    }
}
