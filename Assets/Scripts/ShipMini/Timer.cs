using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timer;
    private bool isTimerRunning;

    // Event triggered when the specified time interval has elapsed
    public delegate void TimeElapsedEventHandler();
    public static event TimeElapsedEventHandler OnTimeElapsed;

    void Start()
    {
        timer = 0f;
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();

            // Check if 10 minutes have passed
            if (timer >= 600f) // 10 minutes = 600 seconds
            {
                if (OnTimeElapsed != null)
                {
                    // Trigger the event
                    OnTimeElapsed();
                    timer = 0f; // Reset the timer
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }

    public void ResetTimer()
    {
        timer = 0f;
        UpdateTimerDisplay();
    }
}
