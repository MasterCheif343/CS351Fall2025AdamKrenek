using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadScoreTrigger : MonoBehaviour
{
    bool active = true;

    public AudioClip badScoreSound;

    private AudioSource playerAudio;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = false;

            //decrease 1 to the score when the player enters the trigger zone
            ScoreManager.score--;
            playerAudio.PlayOneShot(badScoreSound, 1.0f);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;

            //destroy object
            Destroy(gameObject , 2.0f);
        }
    }
}
