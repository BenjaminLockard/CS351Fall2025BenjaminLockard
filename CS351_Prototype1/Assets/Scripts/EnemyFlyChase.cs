using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyChase : MonoBehaviour
{
    public GameObject[] patrolPoints;

    public float speed;
    public float chaseRange;

    public enum EnemyState {  Patrolling, Chasing }

    public EnemyState currentState = EnemyState.Patrolling;

    public GameObject target;

    private GameObject player;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private int currentPatrolPointIndex = 0;


    bool PlayerInRange()
    {
        if (player == null)
        {
            Debug.LogError("Player DNE");
            return false;
        }

        return Vector2.Distance(transform.position, player.transform.position) <= chaseRange;
    }

    void UpdateState()
    {
        if (PlayerInRange() && currentState == EnemyState.Patrolling)
            currentState = EnemyState.Chasing;
        else if (!PlayerInRange() && currentState == EnemyState.Chasing)
            currentState = EnemyState.Patrolling;
    }


    private void Face(Vector2 direction)
    {
        if (direction.x < 0)
            sr.flipX = false;
        else if (direction.x > 0)
            sr.flipX = true;
    }

    void MoveTowardTarget()
    {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        rb.velocity = direction * speed;
        Face(direction);
    }

    void Patrol()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;

        target = patrolPoints[currentPatrolPointIndex];

        MoveTowardTarget();
    }

    void Chase()
    {
        target = player;
        MoveTowardTarget();
    }
    
    
    private void OnDrawGizmos()
    {
        if (patrolPoints != null)
        {
            Gizmos.color = Color.green;
            foreach (GameObject point in patrolPoints)
            {
                Gizmos.DrawWireSphere(point.transform.position, 0.5f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (patrolPoints == null || patrolPoints.Length == 0)
            Debug.LogError("Patrol Points DNE");

        target = patrolPoints[currentPatrolPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        switch(currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                break;
            case EnemyState.Chasing:
                Chase();
                break;
        }

        Debug.DrawLine(transform.position, target.transform.position, Color.red);
    }
}
