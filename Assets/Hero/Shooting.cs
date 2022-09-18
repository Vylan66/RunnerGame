using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
       if (timeBtwShots <= 0)
       {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timeBtwShots = startTimeBtwShots; 
            }
       }
       else
       {
            timeBtwShots -= Time.deltaTime;
       }

    }



    //void Shoot()
    //{
        
    //    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //    rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    //}
}
