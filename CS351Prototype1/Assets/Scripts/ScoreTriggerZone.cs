using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{

    bool active = true;
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = false;

            //Add 1 to the score when the player enters the trigger zone
            ScoreManager.score++;

            //destroy object
            Destroy(gameObject);
        }
    }
}
