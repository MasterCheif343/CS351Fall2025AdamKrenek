using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLoss : MonoBehaviour
{
    public TMP_Text textbox;
    public PlayerHealth death;
    public static bool gameOver;
    public float lowestY;
    public float reachThreashold = 0.1f;
    public Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        death = GetComponent<PlayerHealth>();
        if(death != false && death.death)
        {
            gameOver = true;
            
           textbox.text = "You died! \n Press R to try again";
        }
        if(transform.position.y < lowestY){
            gameOver = true;
        }
       
        
        if (!gameOver)
        {
            gameOver = false;
            textbox.text = "GO!  --> ";
        }
        if (gameOver)
        {
            float distance = Vector2.Distance(transform.position, targetPosition);
            if (distance < reachThreashold)
            {
                Debug.Log("The end has been reached!");
                enabled = false;
                gameOver = true;
                textbox.text = "You win! \n Press R to try again!";
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
