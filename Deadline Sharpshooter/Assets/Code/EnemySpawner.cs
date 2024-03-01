using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]

    private GameObject[] obstacles;

    private float[] arrPosX = { -7f,-2.5f,2f,6.5f };
    
    private float spawnInverval = 3f;

    void Start()
    {
        StartEnemyRoutine();
       
    } 
    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(2f);

        while(true) {
            foreach (float posX in arrPosX)
            {
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
