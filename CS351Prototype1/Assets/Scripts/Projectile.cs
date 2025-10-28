using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//projectile class controls the movement of the bullet
//Attach this to the bullet prefab

public class Projectile : MonoBehaviour
{
    //reference to Rigidbody2D
    private Rigidbody2D rb;

    //speed of bullet, default is set to 20
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Set velocity of bullet to fore to the right at the speed
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
