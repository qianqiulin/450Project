using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    Rigidbody2D _rb;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed=10;
    public float speed=5f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float move = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }

      
        _rb.velocity = new Vector2(move * speed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)){
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
