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

    SpriteRenderer sprite;
    Animator animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        sprite=GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate(){
        animator.SetFloat("Speed",_rb.velocity.magnitude);
        if(_rb.velocity.magnitude>0){
            animator.speed=_rb.velocity.magnitude /25f;  //chage animation speed when moving 
        }
        else{
            animator.speed=1f; //change animation speed when not moving
        }
    }

    void Update()
    {
        float move = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
            sprite.flipX=true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
            sprite.flipX=false;
        }

      
        _rb.velocity = new Vector2(move * speed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)){
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
