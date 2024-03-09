using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]

    private GameObject[] obstacles;

    private float minX = -7f;
    private float maxX = 7f;     
    private float spawnInverval = 3f;
    void Start()
    {
        StartEnemyRoutine();
       
    } 
    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(5f);

        while (true){
            int obstaclesToSpawn = Random.Range(1, obstacles.Length + 1);

            for (int i = 0; i < obstaclesToSpawn; i++)
            {
                float posX = Random.Range(minX, maxX);

                int index = Random.Range(0, obstacles.Length);

                SpawnEnemy(posX, index);
            }
            yield return new WaitForSeconds(spawnInverval);
        }
    }
    void SpawnEnemy(float posX,int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(obstacles[index], spawnPos, Quaternion.identity);
    }
}
