using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    // Set this reference in the inspector
    public GameObject player;
    
  

    // Update is called once per frame
    void Update()
    {
        //Set position of cam to player position
        transform.position = player.transform.position;
    }
}
