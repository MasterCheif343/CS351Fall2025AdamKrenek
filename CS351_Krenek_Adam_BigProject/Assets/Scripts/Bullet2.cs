using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 25;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy2 enemy = hitInfo.GetComponent<Enemy2>();
        if (enemy != null && hitInfo.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        PlayerHealth currentHealth = hitInfo.GetComponent<PlayerHealth>();
            if(hitInfo.gameObject.tag == "Player")
        {
            currentHealth.TakeDamage();
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
