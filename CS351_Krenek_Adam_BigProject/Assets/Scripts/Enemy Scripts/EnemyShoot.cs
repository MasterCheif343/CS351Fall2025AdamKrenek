using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

        // Update is called once per frame
        void Update()
        {


            float distance = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log(distance);

            if (distance < 5)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    timer = 0;
                    Shoot();
                }
            }

        }
        void Shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    
}
