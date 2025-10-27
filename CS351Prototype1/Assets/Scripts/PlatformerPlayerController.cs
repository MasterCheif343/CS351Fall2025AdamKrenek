/* Author: Adam Krenek
 * Date: 9/22/2025
 * Descritpion: Controls platformer player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //Player movment speed
    public float moveSpeed = 5f;

    //force applied when jumping
    public float jumpForce = 10f;

    //Layer mask for detecing ground
    public LayerMask groundLayer;

    //Transform for the position to check for ground
    public Transform groundCheck;

    //Radius for ground check
    public float groundCheckRadius = 0.2f;

    //Reference to Rigidbody2d
    private Rigidbody2D rb;

    //boolean to keep track of if we are on the ground
    private bool isGrounded;

    private float horizontalInput;

    // set this in inspector
    public AudioClip jumpSound;

    //audiosource to play sound effects
    private AudioSource playerAudio;

    //Reference to Animatior
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //Set Referenece to Animator
        animator = GetComponent<Animator>();


        playerAudio = GetComponent<AudioSource>();
        //Get the Rigidbody2D component attached to the game object
        rb = GetComponent<Rigidbody2D>();

        //ensure the ground check variable is assigned
        if(groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //check for jump input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //apply an upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //set animator parameter xVelocityAbs to the absoulte value of x velocity
        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        //set animator parameter yVelocity to y velocity
        animator.SetFloat("yVelocity", rb.velocity.y);

        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //set animator parameter onGround to isGrounded
        animator.SetBool("onGround", isGrounded);

        //ensure the player is facing the direction of movement
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //facing left
        }
      
    }
}
