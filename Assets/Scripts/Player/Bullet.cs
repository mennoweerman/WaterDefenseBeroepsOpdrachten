using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject target;
    public bool SlowEnemy = false;

    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 1.3f);
        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check coll with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            if(SlowEnemy == true){
                if (collision.gameObject.GetComponent<MoveEnemy>())
                {
                    collision.gameObject.GetComponent<MoveEnemy>().SlowEnemy();
                }
            }

            collision.gameObject.GetComponent<Enemy>().TakeDamage(50);
            Destroy(gameObject);
        }
        // Get component enemy.take damage

    }

    private void Update()
    {
        
    }
}
