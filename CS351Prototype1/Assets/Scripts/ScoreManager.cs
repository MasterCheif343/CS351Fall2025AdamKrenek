using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add this to work with TextMeshPro
using TMPro;
//Add this to work with scencemanager to load or reload scences
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    

    public TMP_Text textbox;

    // set this in inspector;
    private int scoreToWin;


    //notice public static variables can be accessed from any script, but can't be seen in inspector
    public static bool gameOver;
    public static bool won;
    public static int score;
    
    void Awake()
    {
        scoreToWin = 10;
    }


    // Start is called before the first frame update
    void Start()
    {
        //set intial values for variables in start()
        gameOver = false;
        won = false;
        score = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            textbox.text = "Score: " + score;
        }

        if (score >= scoreToWin)
        {
            Debug.Log("Won: " + won);
            Debug.Log("Score: " + score);
            Debug.Log("Score to win: " + scoreToWin);


            won = true;
            gameOver = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win! \n Press R to try again!";
            }
            else {
                textbox.text = "You lose! \n Press R to try again";
            }
            // if R is pressed, reload scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
