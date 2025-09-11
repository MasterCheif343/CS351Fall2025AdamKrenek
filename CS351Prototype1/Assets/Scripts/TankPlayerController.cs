using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    // try setting this to 8 in inspector
    // float to hold speed of tank player
    public float speed;

    //float for turn speed
    //try setting this to 100 in inspector
    public float turnSpeed;

    //variables for input
    public float horizontalInput;
    public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        //transform.Translate(1, 0, 0);

        //this does the same thing as the transform  above
        //transform.Translate(Vector3.right);

        // transform.Translate(Vector3.right * Time.deltaTime * speed);

        //Get input in Uodate()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //rotate player with horizontal input
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);


    }
}
