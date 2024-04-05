using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public GameObject fireworkPrefab;
        void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Boundary" && collision.gameObject.tag != "Despawner")
        {
            GameObject firework = Instantiate(fireworkPrefab, collision.transform.position, Quaternion.identity);
            Destroy(firework, 1f);

            // Check if the bullet hits the boss
            Boss boss = collision.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(1); // Cause 1 damage to the boss
            }
            else if (collision.gameObject.tag != "Boss") // Check if it's not the boss to avoid destroying the boss here
            {
                // Destroy the collided object if it's not the boss
                Destroy(collision.gameObject);
            }

            // Notify GameManager to update the score for obstacles
            Obstacles obstacle = collision.gameObject.GetComponent<Obstacles>();
            if (obstacle != null) // Ensure the collided object is an obstacle
            {
                GameManager.instance.AddScore(obstacle.scoreValue);
            }
        }
        
        Destroy(gameObject); // Destroy the bullet
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
