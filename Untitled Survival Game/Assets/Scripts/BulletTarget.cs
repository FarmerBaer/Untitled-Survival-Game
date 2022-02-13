using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{

    public HealthBar healthBar;

    public int health = 100;


    private void Start()
    {
        healthBar.SetMaxHealth(health);
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}
