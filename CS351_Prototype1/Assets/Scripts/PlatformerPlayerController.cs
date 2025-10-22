/* Author: Benjamin Lockard
 * Date: 9/22/2025
 * Assignment: Platformer Follow Along
 * Description: Controls platformer player unit
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //Player movement speed
    public float moveSpeed = 5f;

    // Jump potency
    public float jumpForce = 10f;

    // detect ground
    public LayerMask groundLayer;

    //transform for ground-detecting position
    public Transform groundCheck;

    public float groundCheckRadius;

    //References rigid body
    private Rigidbody2D rb;
    // horisontal var
    private float horizontalInput;
    //vertical var

    // true if grounded
    private bool isGrounded;

    private AudioSource playerAudio;

    public AudioClip jumpSound;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        groundCheckRadius = 0.1f;
        rb = GetComponent<Rigidbody2D>();

        if(groundCheck == null)
        {
            Debug.LogError("groundCheck unassigned to player controller.");
        }

        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("yVelocity", rb.velocity.y);

        animator.SetBool("onGround", isGrounded);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //left
        }
    }

}
