using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float moveSpeed = 1f;
    public int scoreValue;
    public GameObject explosionPrefab;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ShooterController>())
        {
            //Taking away time when the object hits the shooter and then destroying obstacle with an explosion!
            GameManager.instance.SubtractTime();
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
                );
            Destroy(explosion, 0.25f);
            Destroy(gameObject);
        }
                else if (other.gameObject.CompareTag("Bullet")) // Check if the obstacle collides with a bullet
        {
            // Play the hit sound through the SoundManager
            SoundManager.instance.PlaySoundHit();
        }
    }
}
