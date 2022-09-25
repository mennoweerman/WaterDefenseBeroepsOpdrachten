using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGunScript : MonoBehaviour
{
    public bool SlowGun = false;
    public string enemyTag = "Enemy";
    private Shooting shoot;
    private Transform Target;
    public float range = 15f;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float shortestDistance = Mathf.Infinity;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;

        if (SlowGun == true)
        {
            List<MoveEnemy> ObjectsInRange = new List<MoveEnemy>();
            foreach (GameObject go in Enemies)
            {
                if (go.layer == 0 && go.CompareTag("Enemy"))
                {
                    if (Vector3.Distance(transform.position, go.transform.position) <= range)
                    {
                        ObjectsInRange.Add(go.GetComponent<MoveEnemy>());
                        //go. = GetComponent<MoveEnemy>();
                        go.GetComponent<MoveEnemy>().SlowEnemy();
                    }

                }
                if (nearestEnemy != null && shortestDistance <= range && !SlowGun)
                {
                    Target = nearestEnemy.transform;
                    shoot = GetComponent<Shooting>().Shoot();
                    //gameObject.GetComponent<Shooting>().Shoot();
                }
            }
            ObjectsInRange.ToArray();
        }
        
    }
}
