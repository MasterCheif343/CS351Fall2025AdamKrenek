using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab);
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
        if(hit == true) // if this is true the target has been hit
        {
            Debug.Log("Hit" + hit.collider.gameObject);
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.GetDamage();
            }
        }
    }
}
