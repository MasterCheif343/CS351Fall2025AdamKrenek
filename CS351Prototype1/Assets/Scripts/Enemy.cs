using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy's Health
    public int health = 100;

    //Prefab to spawn when enemy dies
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        //subtract the damage dealt from the health
        health -= damage;

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
