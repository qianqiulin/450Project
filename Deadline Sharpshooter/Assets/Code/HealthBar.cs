using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public Image imageHealthBar;
    public GameObject FailuerStage;
    public ShooterController shooter;
    void Start()
    {
        currentHealth = maxHealth;
        imageHealthBar.fillAmount = 1.0f;
        TakeDamage(50);
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
        
        FailuerStage.SetActive(false);
    }
}
