using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLoss : MonoBehaviour
{
    public TMP_Text textbox;
    PlayerHealth currentHealth;
    public static bool gameOver;
    public static bool won;
    public float lowestY;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GetComponent<PlayerHealth>();
        if(currentHealth == null)
        {
            gameOver = true;
            won = false;
           textbox.text = "You lose! \n Press R to try again";
        }
        if(transform.position.y < lowestY){
            gameOver = true;
        }
        //lose when player is too low or falls through pitfall
        
        if (!gameOver)
        {
            gameOver = false;
            textbox.text = "Start: ";
        }
        if (gameOver)
        {
            if (won)
            {
                gameOver = true;
                textbox.text = "You win! \n Press R to try again!";
            }
            else
            {
                textbox.text = "You lose! \n Press R to try again";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
