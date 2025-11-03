using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    public GameObject deathEffect;

    private DisplayBar healthBar;

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.SetValue(health);

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<DisplayBar>();

        if (healthBar == null)
        {
            Debug.LogError("Womp");
            return;
        }

        healthBar.SetMaxValue(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
