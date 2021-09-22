using UnityEngine;
using UnityEngine.UI;

public class MainUIActions : MonoBehaviour
{
    public Text BestScoreText;

    private void Awake()
    {
        int lastBestScore = DataHolder.Instance.GetLastBestScore();
        if (lastBestScore == 0)
        {
            BestScoreText.text = "No scores saved";
        }
        else
        {
            string lastBestScoreUserName = DataHolder.Instance.GetLastBestScoreUserName();
            BestScoreText.text = $"Best score : {lastBestScoreUserName} : {lastBestScore}";
        }
    }
}
