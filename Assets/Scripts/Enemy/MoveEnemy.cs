using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform[] wayPoints;

    [SerializeField]
    public float moveSpeed = 2f;

    public float originalSpeed;

    public float timer = 2f;

    public float originalTimer;

    int waypointIndex = 0;

    public GameObject Enemy;
    private bool isSlowed = false;

    void Start()
    {
        originalSpeed = moveSpeed;
        originalTimer = timer;
        transform.position = wayPoints[waypointIndex].transform.position;
    }

    void Update()
    {


        // attack


        Move();
    }

     public void SlowEnemy()
    {
        if (isSlowed) 
            return;
        StartCoroutine(SlowerTimer());
     }

    public IEnumerator SlowerTimer()
    {
        isSlowed = true;
        moveSpeed = originalSpeed / 2;
        yield return new WaitForSeconds(5);
        moveSpeed = originalSpeed;
        isSlowed = false;
        //timer = originalTimer;
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
