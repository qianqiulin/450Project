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
