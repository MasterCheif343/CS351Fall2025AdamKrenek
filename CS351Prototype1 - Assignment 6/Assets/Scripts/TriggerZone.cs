using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //need this to use TextMeshPro

public class TriggerZone : MonoBehaviour
{
    //set this reference in inspector
    public TMP_Text output;

    //enter text you want to display in inspector
    public string textToDisplay;
  
   

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print test message to console
        //Debug.Log("Triggered by: " + collision.gameObject.name);
        if(collision.gameObject.tag == "Player"){
            output.text = textToDisplay;
            // display You Win!
        }


    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
