using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;
using UnityEditor.Experimental.RestService;

//Require a RigidBody2D and an Animator on enemy
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyMoveWalkingChase : MonoBehaviour
{
    //Range at which the enemy will chase the player
    public float chaseRange = 4f;

    //Speed of the enemy movement
    public float enemyMoveSpeed = 1.5f;

    //Transform of player object
    private Transform playerTransform;

    //Rigidbody component of enemy
    private Rigidbody2D rb;

    //Aniamtor component of enenmy
    private Animator anim;

    //Sprite Renderer of enemy
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //Get sprite renderer
        sr = GetComponent<SpriteRenderer>();
        
        //Get the rigidbody of enemy
        rb = GetComponent<Rigidbody2D>();

        //Get the animator of enemy
        anim = GetComponent<Animator>();

        //Get the player transform using player tag
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //This vector 2 is a 2d arrow from the enemy to the player;
        Vector2 playerDirection = playerTransform.position - transform.position;

        //Distance between enemy and player; the magnitude of the vector is the distance without the direction
        float distanceToPlayer = playerDirection.magnitude;

        //check if player is within chase rangw
        if(distanceToPlayer <= chaseRange)
        {
            //we need the direction of the player only on x axis

            //normalize gives us the direction to the player withour the distance
            playerDirection.Normalize();

            //Setting the y axis to 0 because we only want to move on the x axis
            playerDirection.y = 0f;

            //Rotate the enenmy to face the player
            FacePlayer(playerDirection);

            //If there is any ground ahead of enemy
            if (IsGroundAhead())
            {
                MoveTowardsPlayer(playerDirection);
            }
            //If there is none, stop moving
            else
            {
                StopMoving();
                //Debug.Log("No ground ahead");
            }
        }
        else
        {
            //stop moving if player isn't in chase range
            StopMoving();
        }
    }

   private void FacePlayer(Vector2 playerDirection)
    {
        if (playerDirection.x < 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);

            sr.flipX = false;
            //^faces right
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);

            sr.flipX = true;
            //^ faces left
        }
    }

    bool IsGroundAhead()
    {
        //Ground check variable
        float groundCheckDistance = 2.0f; //adjust this as needed
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        //Determine which direction the enemy is facing
        Vector2 enemyFacingDirection = (sr.flipX == false) ? Vector2.left : Vector2.right;

        //Raycast to check for ground ahead of enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down + enemyFacingDirection, groundCheckDistance, groundLayer);

        //draw a line to show the raycast
        Debug.DrawRay(transform.position, Vector2.down + enemyFacingDirection, Color.red);

        //return true if ground is detected
        return hit.collider != null;
    }

    private void MoveTowardsPlayer(Vector2 playerDirection)
    {   //Move enemy towards the player by setting the velocity
        //To move a new Vector2 without changing the y axis of the velocity
        rb.velocity = new Vector2(playerDirection.x, rb.velocity.y);

        //set the animator parameter to move
        anim.SetBool("isMoving", true);
    }

    void StopMoving()
    {
        //Stop moving if player is out of range
        rb.velocity = new Vector2(0,rb.velocity.y);

        //Set animator parameter to stop moving
        anim.SetBool("isMoving", false);
    }
}
