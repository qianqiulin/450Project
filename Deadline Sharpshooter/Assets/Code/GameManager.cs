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

    // Powerup spawning
    public Transform[] spawnPoints;
    public GameObject[] powerupPrefabs;
    public float delayBetweenPowerupSpawns = 10f;

    void Awake()
    {
        // Initialize the singleton instance
        if (instance == null)
        {
            instance = this;
            UpdateScoreDisplay();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        scoreText.gameObject.SetActive(false); // Make sure the score is not visible initially
        UpdateScoreDisplay();
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

    public void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    public void beginPowerupSpawnTimer() {
        StartCoroutine("PowerupSpawnTimer");
    }

    void SpawnPowerup() {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
        int randomPowerupIndex = Random.Range(0, powerupPrefabs.Length);
        GameObject randomPowerupPrefab = powerupPrefabs[randomPowerupIndex];

        Instantiate(randomPowerupPrefab, randomSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator PowerupSpawnTimer() {
        yield return new WaitForSeconds(delayBetweenPowerupSpawns);

        SpawnPowerup();

        StartCoroutine("PowerupSpawnTimer");
    }
}

