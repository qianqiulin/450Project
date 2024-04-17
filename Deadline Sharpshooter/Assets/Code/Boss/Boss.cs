using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float speed = 5.0f;
    public float increasedSpeed = 7.5f;
    public float verticalMovementRange = 1.5f;
    private bool movingRight = true;
    private float directionChangeCooldown = 0f;
    public float directionChangeInterval = 2f;
    public int maxHP = 50;
    private int currentHP;
    public Image imageHealthBar;
    private float originalY;
    private bool isEnraged = false;
    public GameObject diplomaStage;

    void Start()
    {
        currentHP = maxHP;
        imageHealthBar.fillAmount = 1.0f;
        originalY = transform.position.y;
    }
void Update()
{
    if (BossGameManager.instance.gameStarted)
    {
        HandleMovement();

        if (currentHP <= maxHP * 0.5f && !isEnraged)
        {
            isEnraged = true;
            speed = increasedSpeed;
        }

        if (isEnraged)
        {
            float verticalMovement = Mathf.Sin(Time.time * 2) * verticalMovementRange;
            transform.position = new Vector2(transform.position.x, originalY + verticalMovement); // Possible line 30
        }
    }
}

    private void HandleMovement()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if ((viewportPosition.x > 0.95f || viewportPosition.x < 0.05f) && directionChangeCooldown <= 0f)
        {
            movingRight = !movingRight;
            directionChangeCooldown = directionChangeInterval;
        }

        if (directionChangeCooldown > 0)
        {
            directionChangeCooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        imageHealthBar.fillAmount = (float)currentHP / maxHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        diplomaStage.SetActive(true);
        Time.timeScale = true ? 0 : 1;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            TakeDamage(1);
        }
    }
}
