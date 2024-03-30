using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    private float minX = -7f;
    private float maxX = 7f;     
    private float spawnInterval = 3f;

    private Coroutine spawnRoutine; // Reference to the currently running spawn routine

    // This method will be called to start spawning enemies.
    public void BeginSpawning()
    {
        // If there's already a spawning routine running, stop it before starting a new one.
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
        spawnRoutine = StartCoroutine(EnemyRoutine());
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds before starting to spawn

        while (true)
        {
            int obstaclesToSpawn = Random.Range(1, obstacles.Length + 1);

            for (int i = 0; i < obstaclesToSpawn; i++)
            {
                float posX = Random.Range(minX, maxX);
                int index = Random.Range(0, obstacles.Length);
                SpawnEnemy(posX, index);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(obstacles[index], spawnPos, Quaternion.identity);
    }

    // Optional: A method to stop spawning when the game ends or when not needed
    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
    }
}
