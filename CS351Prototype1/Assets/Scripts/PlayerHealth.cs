using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //variable to store health of player
    public int health = 100;

    //reference to healthbar, must be set in inspector
    public DisplayBar healthBar;

    //reference to player's rigidbody2d, needed for knockback
    private Rigidbody2D rb;

    //variable to track knockback force when  player collides with an enemy
    public float knockbackForce = 5f;

    //prefab to spawn when player dies, must be set in inspector
    public GameObject playerDeath;

    //bool to keep track of if the player was hit recently
    public static bool hitRecently = false;

    //Time in seconds to recover from hit;
    public float hitRecoveryTime;
    // Start is called before the first frame update
    void Start()
    {
        //set rigidbody2d reference
        rb = GetComponent<Rigidbody2D>();

        //check if rigidbody2d reference is null
        if(rb == null)
        {
            Debug.LogError("Rigidbody2D is not found on player");
        }

        //set the healthbar max value to the player's health
        healthBar.SetMaxValue(health);

        //initialize hitRecently to false
        hitRecently = false;
    }
    //function to knock player back when they collide with enemy
    public void Knockback(Vector3 enemyPosition)
    {
        // If the player has been hit recently 
        if (hitRecently)
        {//return out of function
            return;
        }

        //set hitRecently to true
        hitRecently = true;

        //Start coroutine to reset HitRecently
        StartCoroutine(RecoverFromHit());

        //calcualte the direction of knockback
        Vector2 direction = transform.position - enemyPosition;

        //Normalize the direction vector
        //This gives consistent knockback force regardless of the distance between the player and enemy
        direction.Normalize();

        //Add upward direction to knockback
        direction.y = direction.y * 0.5f + 0.5f;

        //Add forec to the player in the direction of the knockback
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    //Corutine to reset hitRecently after hitRecoveryTime seconds
    IEnumerator RecoverFromHit()
    {
        //wait for hitRecoveryTime (0.2) seconds
        yield return new WaitForSeconds(hitRecoveryTime);

        //Set hitRecently to false
        hitRecently=false;
    }
    public void TakeDamage(int damage)
    {
       //Subtract the damage from the health
       health -= damage;

        //update healthbar
        healthBar.SetValue(health);

        //TODO: Play a sound effect when the player takes damage
        //TODO: Play an animation to when the player takes damage

        //if health is less than or equal to 0
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreManager.gameOver = true;

        //TODO: play a sound effect when player dies
        //TODO: add the player death effect when player dies

        //Instantiate the death effect at the player's position
        //GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);

        //Destroy the death effect after 2 seconds
        //Destroy(deathEffect, 2f)
        //disable player object
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
