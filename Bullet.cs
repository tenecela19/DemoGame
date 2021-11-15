using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;
    public float timeToDestroy;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, timeToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
