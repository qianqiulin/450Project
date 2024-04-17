using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float minY = -7;  // makes obstacle disappear

    void Update()
    {
        if (BossGameManager.instance.gameStarted)
        {
            // Your obstacle spawning logic here
            SpawnObstacles();
        }
    }

    void SpawnObstacles()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            //Taking away time when the object hits the shooter and then destroying obstacle with an explosion!
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Boundary")) // Check if the obstacle collides with a bullet
        {
            Destroy(gameObject);
        }
    }
}
