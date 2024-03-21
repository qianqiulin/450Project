using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float moveSpeed=1f;
    public int scoreValue;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<ShooterController>()) {
            //Taking away time when the object hits the shooter
            GameManager.instance.SubtractTime();
        }
    }
}
