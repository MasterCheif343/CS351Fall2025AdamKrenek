using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public float fireRate = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 temPos = pos;
        temPos.y -= speed * Time.deltaTime;
        pos = temPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        switch (other.tag) {
            case "Hero":
                break;
        
        case "HeroLaser":
            Destroy(this.gameObject);
            break;
        }
    }
    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
