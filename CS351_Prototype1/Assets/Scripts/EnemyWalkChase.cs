using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//won't compile w/o components
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyWalkChase : MonoBehaviour
{
    public float chaseRange = 4f;
    public float moveSpeed = 1.5f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;

    bool IsGroundAhead()
    {
        float groundCheckDistance = 2.0f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        //determine direction faced
        Vector2 enemyDirection = playerTransform.rotation.y == 0 ? Vector2.left : Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down + enemyDirection, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    private void FacePlayer(Vector2 playerDirection)
    {
        if (playerDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void MoveTowardPlayer(Vector2 playerDirection)
    {
        rb.velocity = new Vector2(playerDirection.x * moveSpeed, rb.velocity.y);
        anim.SetBool("isMoving", true);
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        Debug.Log("stopped");
        anim.SetBool("isMoving", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDirection = playerTransform.position - transform.position;
        float distanceToPlayer = playerDirection.magnitude;

        if (distanceToPlayer <= chaseRange)
        {
            playerDirection.Normalize();

            playerDirection.y = 0f;

            FacePlayer(playerDirection);

            if(IsGroundAhead())
            {
                MoveTowardPlayer(playerDirection);
            } else
            {
                StopMoving();
            }
        }
    }
}
