using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFlyPatrolChase : MonoBehaviour
{
    //an array of game objects as patrol points
    public GameObject[] patrolPoints;

    //public movement variables
    public float speed = 2f;

    public float chaseRange = 3f;

    //Enemy State enum
    public enum EnemyState { PATROLLING, CHASING }

    //current eney state
    public EnemyState currentState = EnemyState.PATROLLING;

    public GameObject target;

    private GameObject player;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    //current patrol point index
    private int currentPatrolPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //find player
        player = GameObject.FindWithTag("player");

        //get rigidbody component of enemy
        rb = GetComponent<Rigidbody2D>();

        //Get the sprite renderer component of enemy
        sr = GetComponent<SpriteRenderer>();

        //check if patrol points are assigned
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("No patrol points assigned!");
        }

        //set initial target to first patrol point
        target = patrolPoints[currentPatrolPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //Update state bases on player and target distance
        UpdateState();

        //move and face based on current state
        switch (currentState)
        {
            case EnemyState.PATROLLING:
                Patrol();
                break;

            case EnemyState.CHASING:
                ChasePlayer();
                break;

            default:
                Debug.LogError("Invlaid current state on enemy octopus!");
                break;
        }

        //Can use Debug.DrawLine to draw a line between two points
        Debug.DrawLine(transform.position, target.transform.position, Color.red);
    }

    //Update enemy state based on player proximity
    void UpdateState()
    {
        if (IsPlayerInChaseRange() && currentState == EnemyState.PATROLLING)
        {
            currentState = EnemyState.CHASING;
        }
        else if (!IsPlayerInChaseRange() && currentState == EnemyState.CHASING)
        {
            currentState = EnemyState.PATROLLING;
        }
    }

    bool IsPlayerInChaseRange()
    {
        if (player == null)
        {
            Debug.LogError("Player not found");
            return false;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= chaseRange;
    }

    void Patrol()
    {
        //Check if reached current target
        if (Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
        {
            //Update target to next patrol point (wrap around)
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        //Set target to current patrol point
        target = patrolPoints[currentPatrolPointIndex];

        MoveTowardsTarget();
    }

    void ChasePlayer()
    {
        target = player;
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        //calculate direction towards target
        Vector2 direction = target.transform.forward - transform.position;

        //Normalize direction
        direction.Normalize();

        //Move towards target with rb
        rb.velocity = direction * speed;

        //face forward
        FaceForward(direction);
    }

    private void FaceForward(Vector2 direction)
    {
        if (direction.x < 0)
        {
            sr.flipX = false;
        }
        else if (direction.x > 0)
        {
            sr.flipX = true;
        }
    }

    //draw circles for patrol points in the scene view
    private void OnDrawGizmos()
    {
        if(patrolPoints != null)
        {
            Gizmos.color = Color.yellow;
            foreach (GameObject point in patrolPoints)
            {
                Gizmos.DrawWireSphere(point.transform.position, 0.5f);
            }
        }
    }
}
