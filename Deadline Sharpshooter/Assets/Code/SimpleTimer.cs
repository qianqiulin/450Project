using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // You can remove this if you're not using the old UI system.
using TMPro;
using UnityEngine.SceneManagement; // Add this for scene management.

public class SimpleTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text instructionsText;
    private float timeRemaining = 15f; // Start the countdown from 15 seconds
    private bool isRunning = false;
    private bool instructionsOnScreen = true;
    public GameObject ResultPanel;

    void Start()
    {
        // Initialize and start the countdown timer.

        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            if(instructionsOnScreen){
                if(timeRemaining > 0){
                    timeRemaining -= Time.deltaTime;
                } else {
                    instructionsOnScreen = false;
                    Destroy(instructionsText);
                    timeRemaining = 20f;
                }
            } else {
                if (timeRemaining > 0)
                {
                    // Subtract the elapsed time since the last frame from the remaining time
                    timeRemaining -= Time.deltaTime;
                    // Update the UI Text element with the formatted time.
                    if (timerText != null) timerText.text = FormatTime(timeRemaining);
                }
                else
                {
                    // Stop the timer and reset the scene when the countdown reaches zero
                    StopTimer();
                    timeRemaining = 0; // Ensure time doesn't go into negative values                           
                    ResultPanel.SetActive(true);
                }
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
        timeRemaining = 5f; // Reset the countdown to 15 seconds whenever we start the timer
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
    public void playAgain(){
        ResetScene();
    }

    public void increaseTimer(float amountToAdd){
        timeRemaining += amountToAdd;
    }
}
