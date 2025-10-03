/* Author: Adam Krenek
 * Date: 9/22/2025
 * Descritpion: Controls platformer player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody2D component attached to the game object
        rb = GetComponent<Rigidbody2D>();

        //ensure the ground check variable is assigned
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //apply an upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //TODO: optionally we can add aniamtions later

        //ensure the player is facing the direction of movement
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0); //facing right
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //facing left
        }
    }

 
}
