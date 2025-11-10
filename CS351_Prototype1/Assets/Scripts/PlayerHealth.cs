using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public DisplayBar healthBar;

    private Rigidbody2D rb;

    public float knockbackForce;

    public GameObject playerDeathEffect;

    public static bool hitRecently;

    public float hitRecoveryTime = 0.2f;

    public void Knockback(Vector3 enemyPosition)
    {
        if (hitRecently || health <= 0)
            return;
        hitRecently = true;
        StartCoroutine(RecoverFromHit());

        //calculate knockback direction
        Vector2 direction = transform.position - enemyPosition;
        //consistent force regardless of direction, negates lossy diagonals
        direction.Normalize();
        //upward portion of knockback
        direction.y = direction.y * 0.5f + 0.5f;
        //add force in direction of knockback
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetValue(health);

        //TODO: SFX & ANIM for damage

        if (health <= 0)
            Die();
    }

    public void Die()
    {
        ScoreManager.gameOver = true;
        // TODO: SFX & FX for player death

        //GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        //Destroy(deathEffect, 2f);

        gameObject.SetActive(false);
    }

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(hitRecoveryTime);
        hitRecently = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
            Debug.LogError("Rigidbody2D DNE");

        healthBar.SetMaxValue(health);

        hitRecently = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
