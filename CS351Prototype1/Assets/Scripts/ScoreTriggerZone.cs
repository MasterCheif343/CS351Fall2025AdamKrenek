using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip scoreSound;


    bool active = true;
    private void Start()
    {
        // set refernece to audio - make sure to add compomnent
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = false;

            //Add 1 to the score when the player enters the trigger zone
            ScoreManager.score++;

            //play sound
            playerAudio.PlayOneShot(scoreSound, 1.0f);

            //make it disappear
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;

            //destroy object
            Destroy(gameObject,2.0f);
        }
    }
}
