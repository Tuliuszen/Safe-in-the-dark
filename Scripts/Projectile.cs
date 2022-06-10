using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 20f;
    public Rigidbody rb;

    //public Vector3 target;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(lifeTime());
        MoveProjectile();
    }
    public void AddVelocity()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    void FixedUpdate()
    {
        MoveProjectile();
    }
    
    private void MoveProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Walls"))
        //{
        //    Destroy(gameObject);
        //}

        if (this.gameObject.CompareTag("Enemy"))
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().Die();
        }
    }

    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
