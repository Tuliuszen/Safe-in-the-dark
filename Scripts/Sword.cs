using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator swordAnimatorController;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Slash();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Stab();
        }
    }

    void Slash()
    {
        swordAnimatorController.SetTrigger("isSlashing");
    }

    void Stab()
    {
        swordAnimatorController.SetTrigger("isStabing");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

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

}
