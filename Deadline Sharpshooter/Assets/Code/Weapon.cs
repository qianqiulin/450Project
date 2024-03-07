using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab to shoot
    public Transform bulletSpawnPoint; // Where the bullet gets instantiated

    public int maxBullets = 3;
    private int currentBullets;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float cooldownTime = 3f;

    private float lastShootTime;

    void Start()
    {
        currentBullets = maxBullets;
    }

    void Update()
    {
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
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        currentBullets--;
        lastShootTime = Time.time;
    }

    void Reload()
    {
        currentBullets++;
        lastShootTime = Time.time;
    }

    IEnumerator Cooldown()
    {
        isReloading = true;
        yield return new WaitForSeconds(cooldownTime);
        isReloading = false;
        lastShootTime = Time.time;
    }
}
