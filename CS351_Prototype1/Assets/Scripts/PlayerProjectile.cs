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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
