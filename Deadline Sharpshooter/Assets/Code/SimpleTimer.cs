using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SimpleTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text instructionsText;
    private float timeRemaining = 20f; // Start the countdown from 15 seconds
    private bool isRunning = false;
    private bool instructionsOnScreen = true;
    public GameObject ResultPanel;
    public GameObject FailPanel;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            if (instructionsOnScreen)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    timerText.text = FormatTime(timeRemaining);
                }
            }
            else
            {
                if (timeRemaining > 0)
                {
                    decreaseTimer(Time.deltaTime);
                }
                else
                {
                    CalculatingStage();
                }
            }
        }
    }

    public void StartGame()
    {
        instructionsOnScreen = false;
        Destroy(instructionsText.gameObject); // Destroy the GameObject of instructionsText
        timeRemaining = 20f; // Reset timeRemaining for the main timer
        isRunning = true; // Start the timer
    }

    public void StartTimer()
    {
        isRunning = false;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private string FormatTime(float timeToFormat)
    {
        // Since it's a countdown, no need for minutes or milliseconds for a 15-second timer
        int seconds = Mathf.CeilToInt(timeToFormat);
        return seconds.ToString();
    }

    private void ResetScene()
    {
        // Load the current scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void playAgain()
    {
        ResetScene();
    }
    public void nextScene()
    {
        SceneManager.LoadScene("boss");
    }
    public void CalculatingStage()
    {
        StopTimer();
        timeRemaining = 0; // Ensure time doesn't go into negative values                           
        if (GameManager.instance.score >= 30)
        {
            ResultPanel.SetActive(true);
        }
        else if (GameManager.instance.score >= 0 && GameManager.instance.score < 30)
        {
            // If the score is under 30, show the fail panel
            FailPanel.SetActive(true);
        }
    }

    public void increaseTimer(float amountToAdd)
    {
        timeRemaining += amountToAdd;
        timerText.text = FormatTime(timeRemaining);
    }

    public void decreaseTimer(float amountToSubtract)
    {
        if (amountToSubtract < timeRemaining)
        {
            timeRemaining -= amountToSubtract;
            timerText.text = FormatTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerText.text = FormatTime(timeRemaining);
            CalculatingStage();
        }

    }
}
