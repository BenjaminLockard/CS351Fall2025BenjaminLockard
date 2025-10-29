using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ratatatatattatatatattatata projectile
// attatch to proj prefab

public class PlayerProjectile : MonoBehaviour
{
    //rb2d ref
    private Rigidbody2D rb;

    public float speed;

    public int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    void onTriggerEnter2D(Collider hitTrigger)
    {
        Enemy enemy = hitTrigger.gameObject.GetComponent<Enemy>();

        if (enemy != null)
            enemy.takeDamage(damage);

        if (hitTrigger.gameObject.tag != "Player")
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
