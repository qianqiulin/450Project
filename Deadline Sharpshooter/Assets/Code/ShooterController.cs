using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    Rigidbody2D _rb;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed=10;
    public float speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddRelativeForce(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddRelativeForce(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
