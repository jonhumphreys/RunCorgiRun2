using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text TimeText;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public GameTimer GameTimer;
    
    public void SetScoreText(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }
    
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
}
