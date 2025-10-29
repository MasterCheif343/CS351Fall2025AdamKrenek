using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterDelay : MonoBehaviour
{
    //Delay before the game object is destroyed (in seconds)
    public float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy the gameObject
        Destroy(gameObject, delay);
    }

  
}
