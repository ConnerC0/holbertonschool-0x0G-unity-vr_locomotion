using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI timerText;
    public GameObject gameEndScreen;
    public GameObject gameLiveScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI gameOverTimeText;
    public TextMeshProUGUI gameEndTotalKillsText;
    public TextMeshProUGUI gameOverTotalKillsText;
    public StatTracker statTracker;

    private float timer;
    private bool timerRunning;

    private void Start()
    {
        timer = 0f;
        timerRunning = false;
        startButton.onClick.AddListener(StartTimer);
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void StartTimer()
    {
        timerRunning = true;
    }

    private void UpdateTimerText()
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer % 60;
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
    private void UpdateFinalTimeText()
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer % 60;
        finalTimeText.text = $"Final Time: {minutes:00}:{seconds:00}";
        gameOverTimeText.text = $"Final Time: {minutes:00}:{seconds:00}";
    }
    public void StopTimerAndShowEndScreen()
    {
        gameLiveScreen.SetActive(false);
        timerRunning = false;
        UpdateTotalKillsText();
        UpdateFinalTimeText();
        gameEndScreen.SetActive(true);
    }
    public void StopTimerAndShowGameOverScreen()
    {
        gameLiveScreen.SetActive(false);
        timerRunning = false;
        UpdateTotalKillsText();
        UpdateFinalTimeText();
        gameOverScreen.SetActive(true);
    }
    private void UpdateTotalKillsText()
    {
        gameEndTotalKillsText.text = $"Total Kills: {statTracker.zombieKills}";
        gameOverTotalKillsText.text = $"Total Kills: {statTracker.zombieKills}";
    }
}
