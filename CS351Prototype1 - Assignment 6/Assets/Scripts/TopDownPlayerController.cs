using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    //Adjust value in inspector to set player's movement speed
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody2d componet attached to game object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input vaalues for horizontal and vertical movement
        //Use GetAxisRaw so input is either a 1, 0, or -1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //normalizr the movment vector to prevent faster diagonal travel
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        //move player using rigidbody2d in fixedupdate
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
