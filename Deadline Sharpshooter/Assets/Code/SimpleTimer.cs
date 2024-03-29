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
    public GameObject FailPanel;


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
                    //timeRemaining -= Time.deltaTime;
                    // Update the UI Text element with the formatted time.
                    //if (timerText != null) timerText.text = FormatTime(timeRemaining);
                    decreaseTimer(Time.deltaTime);
                }
                else
                {
                    // Stop the timer and reset the scene when the countdown reaches zero
                   CalculatingStage();
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

    public void increaseTimer(float amountToAdd){
        timeRemaining += amountToAdd;
        timerText.text = FormatTime(timeRemaining);
    }

    public void decreaseTimer(float amountToSubtract){
        if(amountToSubtract < timeRemaining)
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
