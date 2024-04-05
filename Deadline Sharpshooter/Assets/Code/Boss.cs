using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 5.0f; // Speed of movement
    private bool movingRight = true; // Track direction of movement
    private float directionChangeCooldown = 0f; // Cooldown time before the next direction change is allowed
    public float directionChangeInterval = 2f; // Minimum time between direction changes
    public int maxHP = 5; // Maximum health points of the boss
    private int currentHP; // Current health points of the boss

    void Start()
    {
        currentHP = maxHP; // Initialize the boss's health when the game starts
    }
    // Update is called once per frame
    void Update()
    {
        // Move the boss in the current direction
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Check if the boss is still within the screen bounds
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if ((viewportPosition.x > 0.95f || viewportPosition.x < 0.05f) && directionChangeCooldown <= 0f)
        {
            movingRight = !movingRight;
            directionChangeCooldown = directionChangeInterval; // Reset cooldown
        }

        // Randomly decide if the boss should change direction, respecting the cooldown
        if (Random.Range(0, 100) < 2 && directionChangeCooldown <= 0f) // Adjust the '2' here to change randomness
        {
            movingRight = !movingRight;
            directionChangeCooldown = directionChangeInterval; // Reset cooldown
        }

        // Update the cooldown timer
        if (directionChangeCooldown > 0)
        {
            directionChangeCooldown -= Time.deltaTime;
        }
    }
        public void TakeDamage(int damage)
    {
        currentHP -= damage; // Reduce the boss's HP

        // Check if the boss's HP has dropped to 0 or below
        if (currentHP <= 0)
        {
            Die();        
        }
    }
        void Die()
    {
        Destroy(gameObject); // Destroy the boss game object
    }
}
