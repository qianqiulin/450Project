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
        if(collision.gameObject.tag != "Boundary" || collision.gameObject.tag != "Despawner") {
            Destroy(collision.gameObject);
            GameObject firework=Instantiate(fireworkPrefab, collision.transform.position, Quaternion.identity);
            // Notify GameManager to update the score
            Obstacles obstacle = collision.gameObject.GetComponent<Obstacles>();
            if (obstacle != null) // Ensure the collided object is an obstacle
            {
                // Notify GameManager to update the score with the obstacle's score value
                GameManager.instance.AddScore(obstacle.scoreValue);
            }
            Destroy(firework, 1f);
        }
        
        Destroy(gameObject);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
