using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f;
    public Text timerText;
    public Image winImage;
    public Image loseImage;

    private bool timerRunning = true;
    private bool win = false;

    void Start()
    {
        if (winImage != null)
        {
            winImage.gameObject.SetActive(false);
        }
        if (loseImage != null)
        {
            loseImage.gameObject.SetActive(false);
        }
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                UpdateTimerUI();
                ShowEndScreen();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Timer : " + Mathf.Ceil(timeRemaining).ToString();
        }
    }

    void ShowEndScreen()
    {
        if (win)
        {
            if (winImage != null)
            {
                winImage.gameObject.SetActive(true);
            }
        }
        else
        {
            if (loseImage != null)
            {
                loseImage.gameObject.SetActive(true);
            }
        }
    }
}