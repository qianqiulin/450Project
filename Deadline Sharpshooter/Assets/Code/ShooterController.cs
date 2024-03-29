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
    public int maxBullets = 3;
    private int currentBullets=3;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float cooldownTime = 3f;

    private float lastShootTime;
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
            animator.speed=_rb.velocity.magnitude /25f;  
        }
        else{
            animator.speed=1f; 
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
        if (Input.GetKeyDown(KeyCode.Space) && currentBullets > 0 && !isReloading)
        {
            Shoot();
            if (currentBullets <= 0)
            {
                StartCoroutine(Cooldown());
            }
        }

        if (!isReloading && currentBullets < maxBullets && Time.time - lastShootTime >= reloadTime)
        {
            Reload();
        }
       
        }
    void Shoot()
        {
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                var bullet=Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
            currentBullets--;
            lastShootTime = Time.time;
        }

        void Reload()
        {
            currentBullets++;
            lastShootTime = Time.time;
        //print("reloading");
        //print(currentBullets);
        }

        IEnumerator Cooldown()
        {
            isReloading = true;
            //print("cooling down");
            yield return new WaitForSeconds(cooldownTime);
            isReloading = false;
            currentBullets = 1;
            lastShootTime = Time.time;
    }

    public int GetCurrentBullets()
    {
        return currentBullets;
    }
}
