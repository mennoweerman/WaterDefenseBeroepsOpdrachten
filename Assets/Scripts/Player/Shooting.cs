using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0.3f;
    public float bulletForce = 20f;


    public Shooting Shoot()
    {
        Invoke("Commit", timer);
        return null;
    }

    void Commit()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce);
    }
}
