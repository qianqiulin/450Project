using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public bool hasInfiniteAmmo = false;
    public float infiniteAmmoTime = 3f;
    public bool isPaused;
    public static ShooterController instance;
    public int maxHealth = 50;
    private int currentHealth;
    public Image imageHealthBar;
    public GameObject FailuerStage;

    private float lastShootTime;
    SpriteRenderer sprite;
    Animator animator;
    
        void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        sprite=GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        imageHealthBar.fillAmount = 1.0f;
        TakeDamage(25);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if((currentBullets > 0 && !isReloading) || hasInfiniteAmmo){
                Shoot();
                if (currentBullets <= 0 && !hasInfiniteAmmo)
                {
                    StartCoroutine(Cooldown());
                }
            }
        }

        if (!isReloading && currentBullets < maxBullets && Time.time - lastShootTime >= reloadTime)
        {
            Reload();
        }
            if(Input.GetKeyDown(KeyCode.Escape)){
        Menu.instance.Show();
    }
        if(isPaused){
            return;
        }
       
        }
    void Shoot()
        {
            TakeDamage(50);
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                var bullet=Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            }
            if(!hasInfiniteAmmo){
                currentBullets--;
            }
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

        // Infinite ammo code

        void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<AmmoPowerup>()) {
            startInfiniteAmmo();
            Destroy(other.gameObject);
        }
    }

        public void startInfiniteAmmo() {
            StartCoroutine(InfiniteAmmo());
        }

        IEnumerator InfiniteAmmo() {
            //print("Infinite Ammo");
            hasInfiniteAmmo = true;
            yield return new WaitForSeconds(infiniteAmmoTime);
            //print("No more infinte ammo");
            hasInfiniteAmmo = false;
        }

    public int GetCurrentBullets()
    {
        return currentBullets;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        imageHealthBar.fillAmount = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Time.timeScale = true ? 0 : 1;
        FailuerStage.SetActive(true);
    }
}
