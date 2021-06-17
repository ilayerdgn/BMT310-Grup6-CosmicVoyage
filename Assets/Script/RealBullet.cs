using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("wall");
            Destroy(gameObject);
        }
    }


}
