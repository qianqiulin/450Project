using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private float moveSpeed =7f;
    private float minY =-7; // makes obstacle disappear
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y <minY){
            Destroy(gameObject);
        }
    }
        private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Bullet"){
            Destroy(gameObject);
        }
    }
}
