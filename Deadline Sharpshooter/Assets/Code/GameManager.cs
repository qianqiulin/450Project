using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance for easy access
    public SimpleTimer timer; //Singleton instance for easy access as well

    public int timeRewardForDestroying;
    public int timePenaltyForGettingHit;
    public TMP_Text scoreText; // Reference to the text component
    public int score = 0; // Initial score

    void Awake()
    {
        // Initialize the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
        timer.increaseTimer(timeRewardForDestroying);
    }

    public void SubtractTime() {
        timer.decreaseTimer(timePenaltyForGettingHit);
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}

