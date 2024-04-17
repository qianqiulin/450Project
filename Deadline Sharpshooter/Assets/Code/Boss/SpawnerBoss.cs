using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = { -7f, -3.5f, 0, 3.5f, 7f };
    [SerializeField]
    private float spawnInterval = 1.5f;
    void Start()
    {
        StartEnemyRoutine();
    }
    public void StartEnemyRoutine()
    {
        if (BossGameManager.instance.gameStarted) // Ensure the game has started
        {
            StartCoroutine("EnemyRoutine");
        }
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); // Initial delay
        while (true)
        {
            foreach (float posX in arrPosX)
            {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, index);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }

    // Call this method from your game start logic
    public void InitiateSpawning()
    {
        if (!BossGameManager.instance.gameStarted)
        {
            BossGameManager.instance.gameStarted = true;
            StartEnemyRoutine();
        }
    }

}
