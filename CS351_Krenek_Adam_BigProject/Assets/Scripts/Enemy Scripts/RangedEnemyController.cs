using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    public Transform shotPoint;
    public Transform gun;

    public GameObject enemyBullet;

    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimebtwnShots;
    private float timeBtwnShots;
   

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f,0f, rotZ);

        if(Vector2.Distance(transform.position, player.position) < followPlayerRange && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        if(Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if(timeBtwnShots <= 0)
            {
                Instantiate(enemyBullet, shotPoint.position, shotPoint.transform.rotation);
                timeBtwnShots = startTimebtwnShots;  
            }
        }
    }
    private void FixedUpdate()
    {
        if(inRange) 
        {
            transform.position =Vector2.MoveTowards(transform.position,player.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
