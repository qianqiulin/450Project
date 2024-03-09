using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{

 public float timeToAdd = 5f; // The amount of time this item adds to the timer

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player")) // Make sure your player GameObject has the "Player" tag
        {
            // Find the SimpleTimer component in the scene and increase the timer
            SimpleTimer timer = FindObjectOfType<SimpleTimer>();
            if (timer != null)
            {
                timer.increaseTimer(timeToAdd);
            }

            // Destroy the time increase item after it's collected
            Destroy(gameObject);
        }
    }
}
