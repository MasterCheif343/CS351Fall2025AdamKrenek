using JetBrains.Annotations;
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

    //Damage of bullet with deafult value of 20
    public int damage = 20;

    //Impact effect of bullet
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Set velocity of bullet to fore to the right at the speed
        rb.velocity = transform.right * speed;

        
    }

    //Function called when bullet collides with another object
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Get enemy component(script) of the object that was hit
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        //If the object that was hit has an enemy component 
        if(enemy != null)
        {
            //call the TakeDamage() function of the Enemy component
            enemy.TakeDamage(damage);
        }
        //If the opbject that was hit is not the player
        if(hitInfo.gameObject.tag != "Player") {

            //instantiate the impact effect
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            //Destroy projectile
            Destroy(gameObject);
        }
    }
}
