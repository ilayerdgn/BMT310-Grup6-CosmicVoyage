using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    float next_spawn_time;

    void Start()
    {
        //start off with next spawn time being 'in 5 seconds'
        next_spawn_time = Time.time + 1.5f;
    }


    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            Fire();

         //increment next_spawn_time
            next_spawn_time += 1.5f;
        }
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
