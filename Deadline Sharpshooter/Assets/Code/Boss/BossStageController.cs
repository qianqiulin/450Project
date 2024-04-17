using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageController : MonoBehaviour
{
    public GameObject instructionPanel; // Assign in inspector
    public SpawnerBoss spawnerBoss;

    void Start()
    {
        // Ensure the instruction panel is visible initially
        instructionPanel.SetActive(true);
    }

    // Call this method when the "Play" button is clicked
    public void StartBossStage()
    {
        spawnerBoss.InitiateSpawning();
        instructionPanel.SetActive(false);
        if (BossGameManager.instance != null)
        {
            BossGameManager.instance.StartGame();
        }


    }
}
