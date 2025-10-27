using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    //reference to bullet prefab
    public GameObject bulletPrefab;


    //reference to firepoint transform
    //This is where the bullet will be instantiated
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //if player presses the fire button and call the shoot function
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() { 
        //instantiate the bullet at firepoint position and rotation
        //and store the reference to the instatiated bullet in a variable
        GameObject firedProjectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //Destroy the bullet after 3 seconds
        Destroy(firedProjectile, 3f);
    }

}
