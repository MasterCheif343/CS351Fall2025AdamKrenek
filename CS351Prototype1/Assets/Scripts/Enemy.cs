using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //reference to healthbar
    private DisplayBar healthBar;

    //Enemy's Health
    public int health = 100;

    //Prefab to spawn when enemy dies
    public GameObject deathEffect;

    private void Start()
    {
        //find healthbar in children of enemy
        healthBar = GetComponentInChildren<DisplayBar>();

        if(healthBar == null)
        {
            //if the health bar is not found, tag as error
            Debug.LogError("HealthBar (DisplayBar Script) not found");
            return;
        }
        healthBar.SetMaxValue(health);
    }
    public void TakeDamage(int damage)
    {
        //subtract the damage dealt from the health
        health -= damage;

        //update health bar 
        healthBar.SetValue(health);

        //If health is less than or equal to 0, enemy dies :(
        if(health <= 0)
        {
            //call die function
            Die();
        }
    }
    
    void Die()
    {
        //Spawn death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //destroy the enemy
        Destroy(gameObject);
    }


}
