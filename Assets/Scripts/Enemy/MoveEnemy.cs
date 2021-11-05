using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform[] wayPoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public GameObject Enemy;

    void Start()
    {

        transform.position = wayPoints[waypointIndex].transform.position;
    }

    void Update()
    {


        // attack


        Move();
    }

     public void SlowEnemy()
    {
        moveSpeed *= .5f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet1")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[waypointIndex].transform.position) < 0.01f)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == wayPoints.Length)
        {
            EndPath();
            return;
        }

        void EndPath()
        {
            PlayerStats.Lives--;
            Destroy(Enemy);
        }

        //Debug.Log(waypointIndex);

    }
}
